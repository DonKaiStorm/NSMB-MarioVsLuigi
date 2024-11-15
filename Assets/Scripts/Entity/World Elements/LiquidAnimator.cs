using Photon.Deterministic;
using Quantum;
using UnityEngine;

namespace NSMB.Entities.World {
    public unsafe class LiquidAnimator : MonoBehaviour {

        //---Serialized Variables
        [SerializeField] private GameObject splashPrefab, splashExitPrefab;
        [SerializeField] private SpriteMask mask;
        [SerializeField] private int pointsPerTile = 8, splashWidth = 2;
        [SerializeField] private float tension = 40, kconstant = 1.5f, damping = 0.92f, splashVelocity = 50f, animationSpeed = 1f;
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private QuantumEntityView entity;

        //---Private Variables
        private Texture2D heightTex;
        private MaterialPropertyBlock properties;
        private Color32[] colors;
        private float[] pointHeights, pointVelocities;
        private float animTimer;
        private int totalPoints;
        private bool initialized;

        private float heightTiles;
        private int widthTiles;

        public void OnValidate() {
            ValidationUtility.SafeOnValidate(() => {
                if (!this) {
                    return;
                }
                QPrototypeLiquid liquid = GetComponent<QPrototypeLiquid>();
                if (liquid) {
                    Initialize(liquid.Prototype.WidthTiles, liquid.Prototype.HeightTiles);
                }
            });
        }

        public void Start() {
            if (entity == null) {
                Initialize(Mathf.RoundToInt(spriteRenderer.size.x * 2), Mathf.RoundToInt(spriteRenderer.size.y * 2) - 1);
            } 

            QuantumEvent.Subscribe<EventLiquidSplashed>(this, OnLiquidSplashed, NetworkHandler.FilterOutReplayFastForward, onlyIfActiveAndEnabled: true);
        }

        public void Initialize(QuantumGame game) {
            var liquid = game.Frames.Predicted.Unsafe.GetPointer<Liquid>(entity.EntityRef);
            Initialize(liquid->WidthTiles, liquid->HeightTiles);
            initialized = true;
        }

        public void Initialize(int width, FP height) {
            widthTiles = width;
            heightTiles = height.AsFloat;

            totalPoints = widthTiles * pointsPerTile;
            pointHeights = new float[totalPoints];
            pointVelocities = new float[totalPoints];
            heightTex = new Texture2D(totalPoints, 1, TextureFormat.RGBA32, false);

            // TODO: eventually, change to a customrendertexture.
            // texture = new CustomRenderTexture(totalPoints, 1, RenderTextureFormat.RInt);

            Color32 gray = new Color(0.5f, 0.5f, 0.5f, 1);
            colors = new Color32[totalPoints];
            for (int i = 0; i < totalPoints; i++) {
                colors[i] = gray;
            }

            heightTex.SetPixels32(colors);
            heightTex.Apply();

            spriteRenderer.size = new(widthTiles * 0.5f, heightTiles * 0.5f + 0.5f);
            if (mask) {
                mask.transform.localScale = new((widthTiles - 2) * mask.sprite.pixelsPerUnit / 32f, (heightTiles - 1) * mask.sprite.pixelsPerUnit / 8f, 1f);
                Debug.Log(mask.transform.localScale);
            }

            properties = new();
            properties.SetTexture("Heightmap", heightTex);
            properties.SetFloat("WidthTiles", widthTiles);
            properties.SetFloat("Height", heightTiles);
            spriteRenderer.SetPropertyBlock(properties);
        }

        public void Update() {
            animTimer += animationSpeed * Time.deltaTime;
            animTimer %= 8;

            properties.SetFloat("TextureIndex", animTimer);
            spriteRenderer.SetPropertyBlock(properties);
        }

        public void FixedUpdate() {
            // TODO: move to a compute shader?
            if (!initialized) {
                return;
            }

            float delta = Time.fixedDeltaTime;

            bool valuesChanged = false;

            for (int i = 0; i < totalPoints; i++) {
                float height = pointHeights[i];
                pointVelocities[i] += tension * -height;
                pointVelocities[i] *= damping;
            }
            for (int i = 0; i < totalPoints; i++) {
                pointHeights[i] += pointVelocities[i] * delta;
            }
            for (int i = 0; i < totalPoints; i++) {
                float height = pointHeights[i];

                pointVelocities[i] -= kconstant * delta * (height - pointHeights[(i + totalPoints - 1) % totalPoints]); // Left
                pointVelocities[i] -= kconstant * delta * (height - pointHeights[(i + totalPoints + 1) % totalPoints]); // Right
            }
            for (int i = 0; i < totalPoints; i++) {
                byte newR = (byte) (Mathf.Clamp01((pointHeights[i] / 20f) + 0.5f) * 255f);
                valuesChanged |= colors[i].r != newR;
                colors[i].r = newR;
            }

            if (valuesChanged) {
                heightTex.SetPixels32(colors);
                heightTex.Apply(false);
            }
        }

        private void OnLiquidSplashed(EventLiquidSplashed e) {
            Instantiate(e.Exit ? splashExitPrefab : splashPrefab, e.Position.ToUnityVector3(), Quaternion.identity);

            float tile = (transform.InverseTransformPoint(e.Position.ToUnityVector3()).x / widthTiles + 0.25f) * 2f;
            int px = (int) (tile * totalPoints);
            for (int i = -splashWidth; i <= splashWidth; i++) {
                int pointsX = px + i;
                pointsX = (int) Mathf.Repeat(pointsX, totalPoints);

                pointVelocities[pointsX] = -splashVelocity * e.Force.AsFloat;
            }
        }
    }
}