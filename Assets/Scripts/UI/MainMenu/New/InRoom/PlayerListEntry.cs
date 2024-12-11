using NSMB.Utils;
using Quantum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace NSMB.UI.MainMenu {
    public class PlayerListEntry : MonoBehaviour, ISelectHandler {

        //---Static Variables
        public static event Action<PlayerListEntry> PlayerMuteStateChanged;
        public static event Action<PlayerListEntry> PlayerEntrySelected;
        public static event Action<PlayerListEntry, bool> PlayerEntryDropdownChanged;

        //---Public Variables
        public PlayerRef player;
        public float typingCounter;
        public UnityEngine.UI.Button button;
        public int joinTick = int.MaxValue;

        //---Serialized Variables
        [SerializeField] private MainMenuCanvas canvas;
        [SerializeField] private TMP_Text nameText, pingText, winsText, muteButtonText;
        [SerializeField] private Image colorStrip;
        [SerializeField] private RectTransform background;
        [SerializeField] private GameObject blockerTemplate, dropdownOptions, firstButton, chattingIcon, settingsIcon, readyIcon;
        [SerializeField] private LayoutElement layout;
        [SerializeField] private GameObject[] allOptions, adminOnlyOptions, othersOnlyOptions;
        [SerializeField] private GameObject playerExistsGameObject;

        //---Private Variables
        private GameObject blockerInstance;
        private EntityRef playerDataEntity;
        private string userId;
        private string nicknameColor;
        private bool constantNicknameColor;

        public void OnEnable() {
            Settings.OnColorblindModeChanged += OnColorblindModeChanged;
            if (QuantumRunner.DefaultGame != null) {
                UpdateText(QuantumRunner.DefaultGame.Frames.Predicted);
            }
            dropdownOptions.SetActive(false);
        }

        public void OnDisable() {
            Settings.OnColorblindModeChanged -= OnColorblindModeChanged;
        }

        public void OnDestroy() {
            if (blockerInstance) {
                Destroy(blockerInstance);
            }
        }

        public void Start() {
            QuantumEvent.Subscribe<EventPlayerDataChanged>(this, OnPlayerDataChanged, onlyIfActiveAndEnabled: true);
            QuantumEvent.Subscribe<EventGameStateChanged>(this, OnGameStateChanged);
            QuantumEvent.Subscribe<EventPlayerStartedTyping>(this, OnPlayerStartedTyping, onlyIfActiveAndEnabled: true);
            QuantumCallback.Subscribe<CallbackUpdateView>(this, OnUpdateView, onlyIfActiveAndEnabled: true);
            playerExistsGameObject.SetActive(false);
        }

        public void OnUpdateView(CallbackUpdateView e) {
            if (!constantNicknameColor) {
                nameText.color = Utils.Utils.SampleNicknameColor(nicknameColor, out _);
            }

            if (typingCounter > 0 && !ChatManager.Instance.mutedPlayers.Contains(userId)) {
                chattingIcon.SetActive(true);
                typingCounter -= Time.deltaTime;
            } else {
                chattingIcon.SetActive(false);
                typingCounter = 0;
            };
        }

        public unsafe void SetPlayer(Frame f, PlayerRef player) {
            this.player = player;
            RuntimePlayer runtimePlayer = QuantumRunner.DefaultGame.Frames.Predicted.GetPlayerData(player);
            nicknameColor = runtimePlayer?.NicknameColor ?? "#FFFFFF";
            userId = runtimePlayer?.UserId;
            nameText.color = Utils.Utils.SampleNicknameColor(nicknameColor, out constantNicknameColor);

            playerExistsGameObject.SetActive(true);
            joinTick = QuantumUtils.GetPlayerData(f, player)->JoinTick;
            name = $"{(runtimePlayer?.PlayerNickname ?? "noname")} ({userId})";
            dropdownOptions.SetActive(false);
        }

        public void RemovePlayer() {
            player = PlayerRef.None;
            nicknameColor = default;
            userId = default;
            joinTick = int.MaxValue;
            playerExistsGameObject.SetActive(false);
            if (dropdownOptions.activeSelf) {
                PlayerEntryDropdownChanged?.Invoke(this, false);
            }
            dropdownOptions.SetActive(false);
        }

        private static readonly StringBuilder Builder = new();
        public unsafe void UpdateText(Frame f) {
            colorStrip.color = Utils.Utils.GetPlayerColor(f, player);
            var playerData = QuantumUtils.GetPlayerData(f, player);
            playerExistsGameObject.SetActive(playerData != null);

            if (playerData == null) {
                return;
            }

            // Wins text
            if (playerData->Wins == 0) {
                winsText.text = "";
            } else {
                winsText.text = "<sprite name=room_wins>" + playerData->Wins;
            }

            // Ping text
            pingText.text = Utils.Utils.GetPingSymbol(playerData->Ping);

            // Name text
            RuntimePlayer runtimePlayer = f.GetPlayerData(player);
            Builder.Clear();

            if (ChatManager.Instance.mutedPlayers.Contains(runtimePlayer.UserId)) {
                Builder.Append("<sprite name=player_muted>");
            }

            if (playerData->IsRoomHost) {
                Builder.Append("<sprite name=room_host>");
            }

            int characterIndex = playerData->Character;
            characterIndex %= GlobalController.Instance.config.CharacterDatas.Length;
            Builder.Append(GlobalController.Instance.config.CharacterDatas[characterIndex].UiString);

            if (f.Global->Rules.TeamsEnabled && Settings.Instance.GraphicsColorblind && !playerData->ManualSpectator) {
                TeamAsset team = f.SimulationConfig.Teams[playerData->Team];
                Builder.Append(team.textSpriteColorblindBig);
            }

            Builder.Append(runtimePlayer.PlayerNickname.ToValidUsername(f, player));
            nameText.text = Builder.ToString();

            Transform parent = transform.parent;
            int childIndex = 0;
            for (int i = 0; i < parent.childCount; i++) {
                if (parent.GetChild(i) != transform) {
                    continue;
                }

                childIndex = i;
                break;
            }

            layout.layoutPriority = transform.parent.childCount - childIndex;
        }

        public unsafe void ShowDropdown() {
            if (blockerInstance) {
                Destroy(blockerInstance);
            }

            foreach (var option in allOptions) {
                option.SetActive(true);
            }

            QuantumGame game = QuantumRunner.DefaultGame;
            bool adminOptions = false;
            foreach (PlayerRef localPlayer in game.GetLocalPlayers()) {
                if (QuantumUtils.GetPlayerData(game.Frames.Predicted, localPlayer)->IsRoomHost) {
                    adminOptions = true;
                    break;
                }
            }

            if (!adminOptions) {
                foreach (var option in adminOnlyOptions) {
                    option.SetActive(false);
                }
            }

            bool othersOptions = !game.PlayerIsLocal(player);
            if (!othersOptions) {
                foreach (var option in othersOnlyOptions) {
                    option.SetActive(false);
                }
            }

            Canvas.ForceUpdateCanvases();

            blockerInstance = Instantiate(blockerTemplate, canvas.transform);
            RectTransform blockerTransform = blockerInstance.GetComponent<RectTransform>();
            blockerTransform.offsetMax = blockerTransform.offsetMin = Vector2.zero;
            blockerInstance.SetActive(true);
            dropdownOptions.SetActive(true);
            PlayerEntryDropdownChanged?.Invoke(this, true);

            EventSystem.current.SetSelectedGameObject(allOptions.First(go => go.activeSelf));
            canvas.PlayCursorSound();
        }

        public void HideDropdown(bool didAction) {
            if (blockerInstance) {
                Destroy(blockerInstance);
            }
            if (dropdownOptions.activeSelf) {
                PlayerEntryDropdownChanged?.Invoke(this, false);
            }
            dropdownOptions.SetActive(false);
            canvas.PlaySound(didAction ? SoundEffect.UI_Decide : SoundEffect.UI_Back);

            EventSystem.current.SetSelectedGameObject(button.gameObject);
        }

        public void BanPlayer() {
            // TODO MainMenuManager.Instance.Ban(player);
            HideDropdown(true);
        }

        public unsafe void KickPlayer() {
            var game = QuantumRunner.DefaultGame;
            PlayerRef host = QuantumUtils.GetHostPlayer(game.Frames.Predicted, out _);
            if (game.PlayerIsLocal(host)) {
                int slot = game.GetLocalPlayerSlots()[game.GetLocalPlayers().IndexOf(host)];
                game.SendCommand(slot, new CommandKickPlayer {
                    Target = player
                });
            }
            HideDropdown(true);
        }

        public void MutePlayer() {
            Frame f = QuantumRunner.DefaultGame.Frames.Predicted;
            RuntimePlayer runtimePlayer = f.GetPlayerData(player);
            if (runtimePlayer != null) {
                HashSet<string> mutedPlayers = ChatManager.Instance.mutedPlayers;
                if (mutedPlayers.Contains(userId)) {
                    mutedPlayers.Remove(userId);
                    ChatManager.Instance.AddSystemMessage("ui.inroom.chat.player.unmuted", ChatManager.Blue, "playername", runtimePlayer.PlayerNickname.ToValidUsername(f, player));
                    muteButtonText.text = GlobalController.Instance.translationManager.GetTranslation("ui.inroom.player.mute");
                } else {
                    mutedPlayers.Add(userId);
                    ChatManager.Instance.AddSystemMessage("ui.inroom.chat.player.muted", ChatManager.Blue, "playername", runtimePlayer.PlayerNickname.ToValidUsername(f, player));
                    muteButtonText.text = GlobalController.Instance.translationManager.GetTranslation("ui.inroom.player.unmute");
                }
            }

            PlayerMuteStateChanged?.Invoke(this);
            UpdateText(f);
            HideDropdown(true);
        }

        public void PromotePlayer() {
            QuantumRunner.DefaultGame.SendCommand(new CommandChangeHost {
                NewHost = player,
            });
            Frame f = QuantumRunner.DefaultGame.Frames.Predicted;
            RuntimePlayer runtimePlayer = f.GetPlayerData(player);
            if (runtimePlayer != null) {
                ChatManager.Instance.AddSystemMessage("ui.inroom.chat.player.promoted", ChatManager.Blue, "playername", runtimePlayer.PlayerNickname.ToValidUsername(f, player));
            }
            HideDropdown(true);
        }

        public void CopyPlayerId() {
            Frame f = QuantumRunner.DefaultGame.Frames.Predicted;
            RuntimePlayer runtimePlayer = f.GetPlayerData(player);

            TextEditor te = new() {
                text = runtimePlayer.UserId.ToString(),
            };
            te.SelectAll();
            te.Copy();
            HideDropdown(true);
        }

        //---Callbacks
        private void OnColorblindModeChanged() {
            UpdateText(QuantumRunner.DefaultGame.Frames.Predicted);
        }

        private void OnGameStateChanged(EventGameStateChanged e) {
            if (e.NewState == GameState.PreGameRoom) {
                UpdateText(e.Frame);
            }
        }

        private unsafe void OnPlayerDataChanged(EventPlayerDataChanged e) {
            if (e.Player != player) {
                return;
            }

            UpdateText(e.Frame);

            var playerData = QuantumUtils.GetPlayerData(e.Frame, e.Player);
            readyIcon.SetActive(playerData->IsReady);
            settingsIcon.SetActive(playerData->IsInSettings);
        }

        public void OnSelect(BaseEventData eventData) {
            PlayerEntrySelected?.Invoke(this);
        }

        private void OnPlayerStartedTyping(EventPlayerStartedTyping e) {
            if (player == e.Player) {
                typingCounter = 4;
            }
        }
    }
}
