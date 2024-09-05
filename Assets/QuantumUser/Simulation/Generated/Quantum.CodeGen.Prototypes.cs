// <auto-generated>
// This code was auto-generated by a tool, every time
// the tool executes this code will be reset.
//
// If you need to extend the classes generated to add
// fields or methods to them, please create partial
// declarations in another file.
// </auto-generated>
#pragma warning disable 0109
#pragma warning disable 1591


namespace Quantum.Prototypes {
  using Photon.Deterministic;
  using Quantum;
  using Quantum.Core;
  using Quantum.Collections;
  using Quantum.Inspector;
  using Quantum.Physics2D;
  using Quantum.Physics3D;
  using Byte = System.Byte;
  using SByte = System.SByte;
  using Int16 = System.Int16;
  using UInt16 = System.UInt16;
  using Int32 = System.Int32;
  using UInt32 = System.UInt32;
  using Int64 = System.Int64;
  using UInt64 = System.UInt64;
  using Boolean = System.Boolean;
  using String = System.String;
  using Object = System.Object;
  using FlagsAttribute = System.FlagsAttribute;
  using SerializableAttribute = System.SerializableAttribute;
  using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
  using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
  using FieldOffsetAttribute = System.Runtime.InteropServices.FieldOffsetAttribute;
  using StructLayoutAttribute = System.Runtime.InteropServices.StructLayoutAttribute;
  using LayoutKind = System.Runtime.InteropServices.LayoutKind;
  #if QUANTUM_UNITY //;
  using TooltipAttribute = UnityEngine.TooltipAttribute;
  using HeaderAttribute = UnityEngine.HeaderAttribute;
  using SpaceAttribute = UnityEngine.SpaceAttribute;
  using RangeAttribute = UnityEngine.RangeAttribute;
  using HideInInspectorAttribute = UnityEngine.HideInInspector;
  using PreserveAttribute = UnityEngine.Scripting.PreserveAttribute;
  using FormerlySerializedAsAttribute = UnityEngine.Serialization.FormerlySerializedAsAttribute;
  using MovedFromAttribute = UnityEngine.Scripting.APIUpdating.MovedFromAttribute;
  using CreateAssetMenu = UnityEngine.CreateAssetMenuAttribute;
  using RuntimeInitializeOnLoadMethodAttribute = UnityEngine.RuntimeInitializeOnLoadMethodAttribute;
  #endif //;
  
  [System.SerializableAttribute()]
  [Quantum.Prototypes.Prototype(typeof(Quantum.BigStar))]
  public unsafe partial class BigStarPrototype : ComponentPrototype<Quantum.BigStar> {
    public QBoolean IsStationary;
    public UInt16 Lifetime;
    public Byte PassthroughFrames;
    public Byte UncollectableFrames;
    public FP Speed;
    public FP BounceForce;
    partial void MaterializeUser(Frame frame, ref Quantum.BigStar result, in PrototypeMaterializationContext context);
    public override Boolean AddToEntity(FrameBase f, EntityRef entity, in PrototypeMaterializationContext context) {
        Quantum.BigStar component = default;
        Materialize((Frame)f, ref component, in context);
        return f.Set(entity, component) == SetResult.ComponentAdded;
    }
    public void Materialize(Frame frame, ref Quantum.BigStar result, in PrototypeMaterializationContext context = default) {
        result.IsStationary = this.IsStationary;
        result.Lifetime = this.Lifetime;
        result.PassthroughFrames = this.PassthroughFrames;
        result.UncollectableFrames = this.UncollectableFrames;
        result.Speed = this.Speed;
        result.BounceForce = this.BounceForce;
        MaterializeUser(frame, ref result, in context);
    }
  }
  [System.SerializableAttribute()]
  [Quantum.Prototypes.Prototype(typeof(Quantum.BlockBump))]
  public unsafe partial class BlockBumpPrototype : ComponentPrototype<Quantum.BlockBump> {
    public Byte Lifetime;
    public AssetRef<StageTile> StartTile;
    public Quantum.Prototypes.StageTileInstancePrototype ResultTile;
    public AssetRef<EntityPrototype> Powerup;
    partial void MaterializeUser(Frame frame, ref Quantum.BlockBump result, in PrototypeMaterializationContext context);
    public override Boolean AddToEntity(FrameBase f, EntityRef entity, in PrototypeMaterializationContext context) {
        Quantum.BlockBump component = default;
        Materialize((Frame)f, ref component, in context);
        return f.Set(entity, component) == SetResult.ComponentAdded;
    }
    public void Materialize(Frame frame, ref Quantum.BlockBump result, in PrototypeMaterializationContext context = default) {
        result.Lifetime = this.Lifetime;
        result.StartTile = this.StartTile;
        this.ResultTile.Materialize(frame, ref result.ResultTile, in context);
        result.Powerup = this.Powerup;
        MaterializeUser(frame, ref result, in context);
    }
  }
  [System.SerializableAttribute()]
  [Quantum.Prototypes.Prototype(typeof(Quantum.Bobomb))]
  public unsafe partial class BobombPrototype : ComponentPrototype<Quantum.Bobomb> {
    public FP ExplosionRadius;
    public FP Speed;
    public UInt16 DetonationFrames;
    partial void MaterializeUser(Frame frame, ref Quantum.Bobomb result, in PrototypeMaterializationContext context);
    public override Boolean AddToEntity(FrameBase f, EntityRef entity, in PrototypeMaterializationContext context) {
        Quantum.Bobomb component = default;
        Materialize((Frame)f, ref component, in context);
        return f.Set(entity, component) == SetResult.ComponentAdded;
    }
    public void Materialize(Frame frame, ref Quantum.Bobomb result, in PrototypeMaterializationContext context = default) {
        result.ExplosionRadius = this.ExplosionRadius;
        result.Speed = this.Speed;
        result.DetonationFrames = this.DetonationFrames;
        MaterializeUser(frame, ref result, in context);
    }
  }
  [System.SerializableAttribute()]
  [Quantum.Prototypes.Prototype(typeof(Quantum.Boo))]
  public unsafe partial class BooPrototype : ComponentPrototype<Quantum.Boo> {
    [HideInInspector()]
    public Int32 _empty_prototype_dummy_field_;
    partial void MaterializeUser(Frame frame, ref Quantum.Boo result, in PrototypeMaterializationContext context);
    public override Boolean AddToEntity(FrameBase f, EntityRef entity, in PrototypeMaterializationContext context) {
        Quantum.Boo component = default;
        Materialize((Frame)f, ref component, in context);
        return f.Set(entity, component) == SetResult.ComponentAdded;
    }
    public void Materialize(Frame frame, ref Quantum.Boo result, in PrototypeMaterializationContext context = default) {
        MaterializeUser(frame, ref result, in context);
    }
  }
  [System.SerializableAttribute()]
  [Quantum.Prototypes.Prototype(typeof(Quantum.BreakableObject))]
  public unsafe partial class BreakableObjectPrototype : ComponentPrototype<Quantum.BreakableObject> {
    public FP OriginalHeight;
    public FP MinimumHeight;
    public QBoolean IsStompable;
    partial void MaterializeUser(Frame frame, ref Quantum.BreakableObject result, in PrototypeMaterializationContext context);
    public override Boolean AddToEntity(FrameBase f, EntityRef entity, in PrototypeMaterializationContext context) {
        Quantum.BreakableObject component = default;
        Materialize((Frame)f, ref component, in context);
        return f.Set(entity, component) == SetResult.ComponentAdded;
    }
    public void Materialize(Frame frame, ref Quantum.BreakableObject result, in PrototypeMaterializationContext context = default) {
        result.OriginalHeight = this.OriginalHeight;
        result.MinimumHeight = this.MinimumHeight;
        result.IsStompable = this.IsStompable;
        MaterializeUser(frame, ref result, in context);
    }
  }
  [System.SerializableAttribute()]
  [Quantum.Prototypes.Prototype(typeof(Quantum.BulletBill))]
  public unsafe partial class BulletBillPrototype : ComponentPrototype<Quantum.BulletBill> {
    public FP Speed;
    public FP DespawnRadius;
    partial void MaterializeUser(Frame frame, ref Quantum.BulletBill result, in PrototypeMaterializationContext context);
    public override Boolean AddToEntity(FrameBase f, EntityRef entity, in PrototypeMaterializationContext context) {
        Quantum.BulletBill component = default;
        Materialize((Frame)f, ref component, in context);
        return f.Set(entity, component) == SetResult.ComponentAdded;
    }
    public void Materialize(Frame frame, ref Quantum.BulletBill result, in PrototypeMaterializationContext context = default) {
        result.Speed = this.Speed;
        result.DespawnRadius = this.DespawnRadius;
        MaterializeUser(frame, ref result, in context);
    }
  }
  [System.SerializableAttribute()]
  [Quantum.Prototypes.Prototype(typeof(Quantum.BulletBillLauncher))]
  public unsafe partial class BulletBillLauncherPrototype : ComponentPrototype<Quantum.BulletBillLauncher> {
    public AssetRef<EntityPrototype> BulletBillPrototype;
    public UInt16 TimeToShoot;
    public FP MinimumShootRadius;
    public FP MaximumShootRadius;
    public Byte BulletBillCount;
    public UInt16 TimeToShootFrames;
    partial void MaterializeUser(Frame frame, ref Quantum.BulletBillLauncher result, in PrototypeMaterializationContext context);
    public override Boolean AddToEntity(FrameBase f, EntityRef entity, in PrototypeMaterializationContext context) {
        Quantum.BulletBillLauncher component = default;
        Materialize((Frame)f, ref component, in context);
        return f.Set(entity, component) == SetResult.ComponentAdded;
    }
    public void Materialize(Frame frame, ref Quantum.BulletBillLauncher result, in PrototypeMaterializationContext context = default) {
        result.BulletBillPrototype = this.BulletBillPrototype;
        result.TimeToShoot = this.TimeToShoot;
        result.MinimumShootRadius = this.MinimumShootRadius;
        result.MaximumShootRadius = this.MaximumShootRadius;
        result.BulletBillCount = this.BulletBillCount;
        result.TimeToShootFrames = this.TimeToShootFrames;
        MaterializeUser(frame, ref result, in context);
    }
  }
  [System.SerializableAttribute()]
  [Quantum.Prototypes.Prototype(typeof(Quantum.CameraController))]
  public unsafe partial class CameraControllerPrototype : ComponentPrototype<Quantum.CameraController> {
    [HideInInspector()]
    public Int32 _empty_prototype_dummy_field_;
    partial void MaterializeUser(Frame frame, ref Quantum.CameraController result, in PrototypeMaterializationContext context);
    public override Boolean AddToEntity(FrameBase f, EntityRef entity, in PrototypeMaterializationContext context) {
        Quantum.CameraController component = default;
        Materialize((Frame)f, ref component, in context);
        return f.Set(entity, component) == SetResult.ComponentAdded;
    }
    public void Materialize(Frame frame, ref Quantum.CameraController result, in PrototypeMaterializationContext context = default) {
        MaterializeUser(frame, ref result, in context);
    }
  }
  [System.SerializableAttribute()]
  [Quantum.Prototypes.Prototype(typeof(Quantum.Coin))]
  public unsafe partial class CoinPrototype : ComponentPrototype<Quantum.Coin> {
    public QBoolean IsFloating;
    public QBoolean IsDotted;
    public UInt16 Lifetime;
    partial void MaterializeUser(Frame frame, ref Quantum.Coin result, in PrototypeMaterializationContext context);
    public override Boolean AddToEntity(FrameBase f, EntityRef entity, in PrototypeMaterializationContext context) {
        Quantum.Coin component = default;
        Materialize((Frame)f, ref component, in context);
        return f.Set(entity, component) == SetResult.ComponentAdded;
    }
    public void Materialize(Frame frame, ref Quantum.Coin result, in PrototypeMaterializationContext context = default) {
        result.IsFloating = this.IsFloating;
        result.IsDotted = this.IsDotted;
        result.Lifetime = this.Lifetime;
        MaterializeUser(frame, ref result, in context);
    }
  }
  [System.SerializableAttribute()]
  [Quantum.Prototypes.Prototype(typeof(Quantum.Enemy))]
  public unsafe partial class EnemyPrototype : ComponentPrototype<Quantum.Enemy> {
    public FPVector2 Spawnpoint;
    public QBoolean IgnorePlayerWhenRespawning;
    partial void MaterializeUser(Frame frame, ref Quantum.Enemy result, in PrototypeMaterializationContext context);
    public override Boolean AddToEntity(FrameBase f, EntityRef entity, in PrototypeMaterializationContext context) {
        Quantum.Enemy component = default;
        Materialize((Frame)f, ref component, in context);
        return f.Set(entity, component) == SetResult.ComponentAdded;
    }
    public void Materialize(Frame frame, ref Quantum.Enemy result, in PrototypeMaterializationContext context = default) {
        result.Spawnpoint = this.Spawnpoint;
        result.IgnorePlayerWhenRespawning = this.IgnorePlayerWhenRespawning;
        MaterializeUser(frame, ref result, in context);
    }
  }
  [System.SerializableAttribute()]
  [Quantum.Prototypes.Prototype(typeof(Quantum.EnterablePipe))]
  public unsafe class EnterablePipePrototype : ComponentPrototype<Quantum.EnterablePipe> {
    public MapEntityId OtherPipe;
    public QBoolean IsEnterable;
    public QBoolean IsCeilingPipe;
    public QBoolean IsMiniOnly;
    public override Boolean AddToEntity(FrameBase f, EntityRef entity, in PrototypeMaterializationContext context) {
        Quantum.EnterablePipe component = default;
        Materialize((Frame)f, ref component, in context);
        return f.Set(entity, component) == SetResult.ComponentAdded;
    }
    public void Materialize(Frame frame, ref Quantum.EnterablePipe result, in PrototypeMaterializationContext context = default) {
        PrototypeValidator.FindMapEntity(this.OtherPipe, in context, out result.OtherPipe);
        result.IsEnterable = this.IsEnterable;
        result.IsCeilingPipe = this.IsCeilingPipe;
        result.IsMiniOnly = this.IsMiniOnly;
    }
  }
  [System.SerializableAttribute()]
  [Quantum.Prototypes.Prototype(typeof(Quantum.Freezable))]
  public unsafe partial class FreezablePrototype : ComponentPrototype<Quantum.Freezable> {
    [HideInInspector()]
    public Int32 _empty_prototype_dummy_field_;
    partial void MaterializeUser(Frame frame, ref Quantum.Freezable result, in PrototypeMaterializationContext context);
    public override Boolean AddToEntity(FrameBase f, EntityRef entity, in PrototypeMaterializationContext context) {
        Quantum.Freezable component = default;
        Materialize((Frame)f, ref component, in context);
        return f.Set(entity, component) == SetResult.ComponentAdded;
    }
    public void Materialize(Frame frame, ref Quantum.Freezable result, in PrototypeMaterializationContext context = default) {
        MaterializeUser(frame, ref result, in context);
    }
  }
  [System.SerializableAttribute()]
  [Quantum.Prototypes.Prototype(typeof(Quantum.FrozenCube))]
  public unsafe partial class FrozenCubePrototype : ComponentPrototype<Quantum.FrozenCube> {
    [HideInInspector()]
    public Int32 _empty_prototype_dummy_field_;
    partial void MaterializeUser(Frame frame, ref Quantum.FrozenCube result, in PrototypeMaterializationContext context);
    public override Boolean AddToEntity(FrameBase f, EntityRef entity, in PrototypeMaterializationContext context) {
        Quantum.FrozenCube component = default;
        Materialize((Frame)f, ref component, in context);
        return f.Set(entity, component) == SetResult.ComponentAdded;
    }
    public void Materialize(Frame frame, ref Quantum.FrozenCube result, in PrototypeMaterializationContext context = default) {
        MaterializeUser(frame, ref result, in context);
    }
  }
  [System.SerializableAttribute()]
  [Quantum.Prototypes.Prototype(typeof(Quantum.GenericMover))]
  public unsafe partial class GenericMoverPrototype : ComponentPrototype<Quantum.GenericMover> {
    public AssetRef<GenericMoverAsset> MoverAsset;
    public FP StartOffset;
    partial void MaterializeUser(Frame frame, ref Quantum.GenericMover result, in PrototypeMaterializationContext context);
    public override Boolean AddToEntity(FrameBase f, EntityRef entity, in PrototypeMaterializationContext context) {
        Quantum.GenericMover component = default;
        Materialize((Frame)f, ref component, in context);
        return f.Set(entity, component) == SetResult.ComponentAdded;
    }
    public void Materialize(Frame frame, ref Quantum.GenericMover result, in PrototypeMaterializationContext context = default) {
        result.MoverAsset = this.MoverAsset;
        result.StartOffset = this.StartOffset;
        MaterializeUser(frame, ref result, in context);
    }
  }
  [System.SerializableAttribute()]
  [Quantum.Prototypes.Prototype(typeof(Quantum.Goomba))]
  public unsafe partial class GoombaPrototype : ComponentPrototype<Quantum.Goomba> {
    public Byte DeathAnimationFrames;
    public FP Speed;
    partial void MaterializeUser(Frame frame, ref Quantum.Goomba result, in PrototypeMaterializationContext context);
    public override Boolean AddToEntity(FrameBase f, EntityRef entity, in PrototypeMaterializationContext context) {
        Quantum.Goomba component = default;
        Materialize((Frame)f, ref component, in context);
        return f.Set(entity, component) == SetResult.ComponentAdded;
    }
    public void Materialize(Frame frame, ref Quantum.Goomba result, in PrototypeMaterializationContext context = default) {
        result.DeathAnimationFrames = this.DeathAnimationFrames;
        result.Speed = this.Speed;
        MaterializeUser(frame, ref result, in context);
    }
  }
  [System.SerializableAttribute()]
  [Quantum.Prototypes.Prototype(typeof(Quantum.Holdable))]
  public unsafe partial class HoldablePrototype : ComponentPrototype<Quantum.Holdable> {
    public QBoolean HoldAboveHead;
    partial void MaterializeUser(Frame frame, ref Quantum.Holdable result, in PrototypeMaterializationContext context);
    public override Boolean AddToEntity(FrameBase f, EntityRef entity, in PrototypeMaterializationContext context) {
        Quantum.Holdable component = default;
        Materialize((Frame)f, ref component, in context);
        return f.Set(entity, component) == SetResult.ComponentAdded;
    }
    public void Materialize(Frame frame, ref Quantum.Holdable result, in PrototypeMaterializationContext context = default) {
        result.HoldAboveHead = this.HoldAboveHead;
        MaterializeUser(frame, ref result, in context);
    }
  }
  [System.SerializableAttribute()]
  [Quantum.Prototypes.Prototype(typeof(Quantum.Input))]
  public unsafe partial class InputPrototype : StructPrototype {
    public Button Up;
    public Button Down;
    public Button Left;
    public Button Right;
    public Button Jump;
    public Button Sprint;
    public Button PowerupAction;
    public Button FireballPowerupAction;
    public Button PropellerPowerupAction;
    partial void MaterializeUser(Frame frame, ref Quantum.Input result, in PrototypeMaterializationContext context);
    public void Materialize(Frame frame, ref Quantum.Input result, in PrototypeMaterializationContext context = default) {
        result.Up = this.Up;
        result.Down = this.Down;
        result.Left = this.Left;
        result.Right = this.Right;
        result.Jump = this.Jump;
        result.Sprint = this.Sprint;
        result.PowerupAction = this.PowerupAction;
        result.FireballPowerupAction = this.FireballPowerupAction;
        result.PropellerPowerupAction = this.PropellerPowerupAction;
        MaterializeUser(frame, ref result, in context);
    }
  }
  [System.SerializableAttribute()]
  [Quantum.Prototypes.Prototype(typeof(Quantum.Interactable))]
  public unsafe partial class InteractablePrototype : ComponentPrototype<Quantum.Interactable> {
    public QBoolean ColliderDisabled;
    partial void MaterializeUser(Frame frame, ref Quantum.Interactable result, in PrototypeMaterializationContext context);
    public override Boolean AddToEntity(FrameBase f, EntityRef entity, in PrototypeMaterializationContext context) {
        Quantum.Interactable component = default;
        Materialize((Frame)f, ref component, in context);
        return f.Set(entity, component) == SetResult.ComponentAdded;
    }
    public void Materialize(Frame frame, ref Quantum.Interactable result, in PrototypeMaterializationContext context = default) {
        result.ColliderDisabled = this.ColliderDisabled;
        MaterializeUser(frame, ref result, in context);
    }
  }
  [System.SerializableAttribute()]
  [Quantum.Prototypes.Prototype(typeof(Quantum.Koopa))]
  public unsafe partial class KoopaPrototype : ComponentPrototype<Quantum.Koopa> {
    public AssetRef<PowerupAsset> SpawnPowerupWhenStomped;
    public QBoolean DontWalkOfLedges;
    public QBoolean IsSpiny;
    public FP Speed;
    public FP KickSpeed;
    partial void MaterializeUser(Frame frame, ref Quantum.Koopa result, in PrototypeMaterializationContext context);
    public override Boolean AddToEntity(FrameBase f, EntityRef entity, in PrototypeMaterializationContext context) {
        Quantum.Koopa component = default;
        Materialize((Frame)f, ref component, in context);
        return f.Set(entity, component) == SetResult.ComponentAdded;
    }
    public void Materialize(Frame frame, ref Quantum.Koopa result, in PrototypeMaterializationContext context = default) {
        result.SpawnPowerupWhenStomped = this.SpawnPowerupWhenStomped;
        result.DontWalkOfLedges = this.DontWalkOfLedges;
        result.IsSpiny = this.IsSpiny;
        result.Speed = this.Speed;
        result.KickSpeed = this.KickSpeed;
        MaterializeUser(frame, ref result, in context);
    }
  }
  [System.SerializableAttribute()]
  [Quantum.Prototypes.Prototype(typeof(Quantum.Liquid))]
  public unsafe partial class LiquidPrototype : ComponentPrototype<Quantum.Liquid> {
    public LiquidType LiquidType;
    public Int32 WidthTiles;
    public FP HeightTiles;
    partial void MaterializeUser(Frame frame, ref Quantum.Liquid result, in PrototypeMaterializationContext context);
    public override Boolean AddToEntity(FrameBase f, EntityRef entity, in PrototypeMaterializationContext context) {
        Quantum.Liquid component = default;
        Materialize((Frame)f, ref component, in context);
        return f.Set(entity, component) == SetResult.ComponentAdded;
    }
    public void Materialize(Frame frame, ref Quantum.Liquid result, in PrototypeMaterializationContext context = default) {
        result.LiquidType = this.LiquidType;
        result.WidthTiles = this.WidthTiles;
        result.HeightTiles = this.HeightTiles;
        MaterializeUser(frame, ref result, in context);
    }
  }
  [System.SerializableAttribute()]
  [Quantum.Prototypes.Prototype(typeof(Quantum.MarioBrosPlatform))]
  public unsafe partial class MarioBrosPlatformPrototype : ComponentPrototype<Quantum.MarioBrosPlatform> {
    [HideInInspector()]
    public Int32 _empty_prototype_dummy_field_;
    partial void MaterializeUser(Frame frame, ref Quantum.MarioBrosPlatform result, in PrototypeMaterializationContext context);
    public override Boolean AddToEntity(FrameBase f, EntityRef entity, in PrototypeMaterializationContext context) {
        Quantum.MarioBrosPlatform component = default;
        Materialize((Frame)f, ref component, in context);
        return f.Set(entity, component) == SetResult.ComponentAdded;
    }
    public void Materialize(Frame frame, ref Quantum.MarioBrosPlatform result, in PrototypeMaterializationContext context = default) {
        MaterializeUser(frame, ref result, in context);
    }
  }
  [System.SerializableAttribute()]
  [Quantum.Prototypes.Prototype(typeof(Quantum.MarioPlayer))]
  public unsafe class MarioPlayerPrototype : ComponentPrototype<Quantum.MarioPlayer> {
    public AssetRef<MarioPlayerPhysicsInfo> PhysicsAsset;
    public AssetRef<CharacterAsset> CharacterAsset;
    public PlayerRef PlayerRef;
    public Byte SpawnpointIndex;
    public Byte Team;
    public PowerupState CurrentPowerupState;
    public PowerupState PreviousPowerupState;
    public AssetRef<PowerupAsset> ReserveItem;
    public Byte Stars;
    public Byte Coins;
    public Byte Lives;
    public QBoolean Disconnected;
    public QBoolean IsDead;
    public QBoolean FireDeath;
    public QBoolean IsRespawning;
    public Byte DeathAnimationFrames;
    public Byte PreRespawnFrames;
    public Byte RespawnFrames;
    public Byte NoLivesStarDirection;
    public QBoolean FacingRight;
    public QBoolean IsSkidding;
    public QBoolean IsTurnaround;
    public Byte FastTurnaroundFrames;
    public Byte SlowTurnaroundFrames;
    public JumpState JumpState;
    public JumpState PreviousJumpState;
    public Byte JumpLandingFrames;
    public Byte JumpBufferFrames;
    public Byte CoyoteTimeFrames;
    public Int32 LandedFrame;
    public QBoolean WasTouchingGroundLastFrame;
    public QBoolean DoEntityBounce;
    public QBoolean WallslideLeft;
    public QBoolean WallslideRight;
    public Byte WallslideEndFrames;
    public Byte WalljumpFrames;
    public QBoolean IsGroundpounding;
    public QBoolean IsGroundpoundActive;
    public Byte GroundpoundStartFrames;
    public Byte GroundpoundCooldownFrames;
    public Byte GroundpoundStandFrames;
    public Byte WaterColliderCount;
    public QBoolean SwimExitForceJump;
    public QBoolean IsInKnockback;
    public QBoolean IsInWeakKnockback;
    public QBoolean KnockbackWasOriginallyFacingRight;
    public Int32 KnockbackTick;
    public Byte DamageInvincibilityFrames;
    public QBoolean IsCrouching;
    public QBoolean IsSliding;
    public QBoolean IsSpinnerFlying;
    public QBoolean IsDrilling;
    public Byte Combo;
    public UInt16 InvincibilityFrames;
    public Byte MegaMushroomStartFrames;
    public UInt16 MegaMushroomFrames;
    public Byte MegaMushroomEndFrames;
    public QBoolean MegaMushroomStationaryEnd;
    public Byte ProjectileDelayFrames;
    public Byte ProjectileVolleyFrames;
    public Byte CurrentProjectiles;
    public Byte CurrentVolley;
    public QBoolean IsInShell;
    public Byte ShellSlowdownFrames;
    public QBoolean IsPropellerFlying;
    public Byte PropellerLaunchFrames;
    public Byte PropellerSpinFrames;
    public QBoolean UsedPropellerThisJump;
    public Byte PropellerDrillCooldown;
    public MapEntityId HeldEntity;
    public MapEntityId CurrentPipe;
    public FPVector2 PipeDirection;
    public QBoolean PipeEntering;
    public Byte PipeFrames;
    public Byte PipeCooldownFrames;
    public override Boolean AddToEntity(FrameBase f, EntityRef entity, in PrototypeMaterializationContext context) {
        Quantum.MarioPlayer component = default;
        Materialize((Frame)f, ref component, in context);
        return f.Set(entity, component) == SetResult.ComponentAdded;
    }
    public void Materialize(Frame frame, ref Quantum.MarioPlayer result, in PrototypeMaterializationContext context = default) {
        result.PhysicsAsset = this.PhysicsAsset;
        result.CharacterAsset = this.CharacterAsset;
        result.PlayerRef = this.PlayerRef;
        result.SpawnpointIndex = this.SpawnpointIndex;
        result.Team = this.Team;
        result.CurrentPowerupState = this.CurrentPowerupState;
        result.PreviousPowerupState = this.PreviousPowerupState;
        result.ReserveItem = this.ReserveItem;
        result.Stars = this.Stars;
        result.Coins = this.Coins;
        result.Lives = this.Lives;
        result.Disconnected = this.Disconnected;
        result.IsDead = this.IsDead;
        result.FireDeath = this.FireDeath;
        result.IsRespawning = this.IsRespawning;
        result.DeathAnimationFrames = this.DeathAnimationFrames;
        result.PreRespawnFrames = this.PreRespawnFrames;
        result.RespawnFrames = this.RespawnFrames;
        result.NoLivesStarDirection = this.NoLivesStarDirection;
        result.FacingRight = this.FacingRight;
        result.IsSkidding = this.IsSkidding;
        result.IsTurnaround = this.IsTurnaround;
        result.FastTurnaroundFrames = this.FastTurnaroundFrames;
        result.SlowTurnaroundFrames = this.SlowTurnaroundFrames;
        result.JumpState = this.JumpState;
        result.PreviousJumpState = this.PreviousJumpState;
        result.JumpLandingFrames = this.JumpLandingFrames;
        result.JumpBufferFrames = this.JumpBufferFrames;
        result.CoyoteTimeFrames = this.CoyoteTimeFrames;
        result.LandedFrame = this.LandedFrame;
        result.WasTouchingGroundLastFrame = this.WasTouchingGroundLastFrame;
        result.DoEntityBounce = this.DoEntityBounce;
        result.WallslideLeft = this.WallslideLeft;
        result.WallslideRight = this.WallslideRight;
        result.WallslideEndFrames = this.WallslideEndFrames;
        result.WalljumpFrames = this.WalljumpFrames;
        result.IsGroundpounding = this.IsGroundpounding;
        result.IsGroundpoundActive = this.IsGroundpoundActive;
        result.GroundpoundStartFrames = this.GroundpoundStartFrames;
        result.GroundpoundCooldownFrames = this.GroundpoundCooldownFrames;
        result.GroundpoundStandFrames = this.GroundpoundStandFrames;
        result.WaterColliderCount = this.WaterColliderCount;
        result.SwimExitForceJump = this.SwimExitForceJump;
        result.IsInKnockback = this.IsInKnockback;
        result.IsInWeakKnockback = this.IsInWeakKnockback;
        result.KnockbackWasOriginallyFacingRight = this.KnockbackWasOriginallyFacingRight;
        result.KnockbackTick = this.KnockbackTick;
        result.DamageInvincibilityFrames = this.DamageInvincibilityFrames;
        result.IsCrouching = this.IsCrouching;
        result.IsSliding = this.IsSliding;
        result.IsSpinnerFlying = this.IsSpinnerFlying;
        result.IsDrilling = this.IsDrilling;
        result.Combo = this.Combo;
        result.InvincibilityFrames = this.InvincibilityFrames;
        result.MegaMushroomStartFrames = this.MegaMushroomStartFrames;
        result.MegaMushroomFrames = this.MegaMushroomFrames;
        result.MegaMushroomEndFrames = this.MegaMushroomEndFrames;
        result.MegaMushroomStationaryEnd = this.MegaMushroomStationaryEnd;
        result.ProjectileDelayFrames = this.ProjectileDelayFrames;
        result.ProjectileVolleyFrames = this.ProjectileVolleyFrames;
        result.CurrentProjectiles = this.CurrentProjectiles;
        result.CurrentVolley = this.CurrentVolley;
        result.IsInShell = this.IsInShell;
        result.ShellSlowdownFrames = this.ShellSlowdownFrames;
        result.IsPropellerFlying = this.IsPropellerFlying;
        result.PropellerLaunchFrames = this.PropellerLaunchFrames;
        result.PropellerSpinFrames = this.PropellerSpinFrames;
        result.UsedPropellerThisJump = this.UsedPropellerThisJump;
        result.PropellerDrillCooldown = this.PropellerDrillCooldown;
        PrototypeValidator.FindMapEntity(this.HeldEntity, in context, out result.HeldEntity);
        PrototypeValidator.FindMapEntity(this.CurrentPipe, in context, out result.CurrentPipe);
        result.PipeDirection = this.PipeDirection;
        result.PipeEntering = this.PipeEntering;
        result.PipeFrames = this.PipeFrames;
        result.PipeCooldownFrames = this.PipeCooldownFrames;
    }
  }
  [System.SerializableAttribute()]
  [Quantum.Prototypes.Prototype(typeof(Quantum.MovingPlatform))]
  public unsafe partial class MovingPlatformPrototype : ComponentPrototype<Quantum.MovingPlatform> {
    public FPVector2 Velocity;
    partial void MaterializeUser(Frame frame, ref Quantum.MovingPlatform result, in PrototypeMaterializationContext context);
    public override Boolean AddToEntity(FrameBase f, EntityRef entity, in PrototypeMaterializationContext context) {
        Quantum.MovingPlatform component = default;
        Materialize((Frame)f, ref component, in context);
        return f.Set(entity, component) == SetResult.ComponentAdded;
    }
    public void Materialize(Frame frame, ref Quantum.MovingPlatform result, in PrototypeMaterializationContext context = default) {
        result.Velocity = this.Velocity;
        MaterializeUser(frame, ref result, in context);
    }
  }
  [System.SerializableAttribute()]
  [Quantum.Prototypes.Prototype(typeof(Quantum.PhysicsContact))]
  public unsafe class PhysicsContactPrototype : StructPrototype {
    public FPVector2 Position;
    public FPVector2 Normal;
    public FP Distance;
    public Int32 Frame;
    public Int32 TileX;
    public Int32 TileY;
    public MapEntityId Entity;
    public void Materialize(Frame frame, ref Quantum.PhysicsContact result, in PrototypeMaterializationContext context = default) {
        result.Position = this.Position;
        result.Normal = this.Normal;
        result.Distance = this.Distance;
        result.Frame = this.Frame;
        result.TileX = this.TileX;
        result.TileY = this.TileY;
        PrototypeValidator.FindMapEntity(this.Entity, in context, out result.Entity);
    }
  }
  [System.SerializableAttribute()]
  [Quantum.Prototypes.Prototype(typeof(Quantum.PhysicsObject))]
  public unsafe class PhysicsObjectPrototype : ComponentPrototype<Quantum.PhysicsObject> {
    public FPVector2 Gravity;
    public FP TerminalVelocity;
    public QBoolean IsFrozen;
    public QBoolean DisableCollision;
    public override Boolean AddToEntity(FrameBase f, EntityRef entity, in PrototypeMaterializationContext context) {
        Quantum.PhysicsObject component = default;
        Materialize((Frame)f, ref component, in context);
        return f.Set(entity, component) == SetResult.ComponentAdded;
    }
    public void Materialize(Frame frame, ref Quantum.PhysicsObject result, in PrototypeMaterializationContext context = default) {
        result.Gravity = this.Gravity;
        result.TerminalVelocity = this.TerminalVelocity;
        result.IsFrozen = this.IsFrozen;
        result.DisableCollision = this.DisableCollision;
    }
  }
  [System.SerializableAttribute()]
  [Quantum.Prototypes.Prototype(typeof(Quantum.PiranhaPlant))]
  public unsafe class PiranhaPlantPrototype : ComponentPrototype<Quantum.PiranhaPlant> {
    public MapEntityId Pipe;
    public override Boolean AddToEntity(FrameBase f, EntityRef entity, in PrototypeMaterializationContext context) {
        Quantum.PiranhaPlant component = default;
        Materialize((Frame)f, ref component, in context);
        return f.Set(entity, component) == SetResult.ComponentAdded;
    }
    public void Materialize(Frame frame, ref Quantum.PiranhaPlant result, in PrototypeMaterializationContext context = default) {
        PrototypeValidator.FindMapEntity(this.Pipe, in context, out result.Pipe);
    }
  }
  [System.SerializableAttribute()]
  [Quantum.Prototypes.Prototype(typeof(Quantum.Powerup))]
  public unsafe partial class PowerupPrototype : ComponentPrototype<Quantum.Powerup> {
    public AssetRef<PowerupAsset> Scriptable;
    public QBoolean FacingRight;
    public Int32 Lifetime;
    public FPVector2 AnimationCurveOrigin;
    public FP AnimationCurveTimer;
    partial void MaterializeUser(Frame frame, ref Quantum.Powerup result, in PrototypeMaterializationContext context);
    public override Boolean AddToEntity(FrameBase f, EntityRef entity, in PrototypeMaterializationContext context) {
        Quantum.Powerup component = default;
        Materialize((Frame)f, ref component, in context);
        return f.Set(entity, component) == SetResult.ComponentAdded;
    }
    public void Materialize(Frame frame, ref Quantum.Powerup result, in PrototypeMaterializationContext context = default) {
        result.Scriptable = this.Scriptable;
        result.FacingRight = this.FacingRight;
        result.Lifetime = this.Lifetime;
        result.AnimationCurveOrigin = this.AnimationCurveOrigin;
        result.AnimationCurveTimer = this.AnimationCurveTimer;
        MaterializeUser(frame, ref result, in context);
    }
  }
  [System.SerializableAttribute()]
  [Quantum.Prototypes.Prototype(typeof(Quantum.Projectile))]
  public unsafe partial class ProjectilePrototype : ComponentPrototype<Quantum.Projectile> {
    public AssetRef<ProjectileAsset> Asset;
    public FP Speed;
    partial void MaterializeUser(Frame frame, ref Quantum.Projectile result, in PrototypeMaterializationContext context);
    public override Boolean AddToEntity(FrameBase f, EntityRef entity, in PrototypeMaterializationContext context) {
        Quantum.Projectile component = default;
        Materialize((Frame)f, ref component, in context);
        return f.Set(entity, component) == SetResult.ComponentAdded;
    }
    public void Materialize(Frame frame, ref Quantum.Projectile result, in PrototypeMaterializationContext context = default) {
        result.Asset = this.Asset;
        result.Speed = this.Speed;
        MaterializeUser(frame, ref result, in context);
    }
  }
  [System.SerializableAttribute()]
  [Quantum.Prototypes.Prototype(typeof(Quantum.StageTileInstance))]
  public unsafe partial class StageTileInstancePrototype : StructPrototype {
    public AssetRef<StageTile> Tile;
    public FP Rotation;
    public FPVector2 Scale;
    partial void MaterializeUser(Frame frame, ref Quantum.StageTileInstance result, in PrototypeMaterializationContext context);
    public void Materialize(Frame frame, ref Quantum.StageTileInstance result, in PrototypeMaterializationContext context = default) {
        result.Tile = this.Tile;
        result.Rotation = this.Rotation;
        result.Scale = this.Scale;
        MaterializeUser(frame, ref result, in context);
    }
  }
  [System.SerializableAttribute()]
  [Quantum.Prototypes.Prototype(typeof(Quantum.WrappingObject))]
  public unsafe partial class WrappingObjectPrototype : ComponentPrototype<Quantum.WrappingObject> {
    [HideInInspector()]
    public Int32 _empty_prototype_dummy_field_;
    partial void MaterializeUser(Frame frame, ref Quantum.WrappingObject result, in PrototypeMaterializationContext context);
    public override Boolean AddToEntity(FrameBase f, EntityRef entity, in PrototypeMaterializationContext context) {
        Quantum.WrappingObject component = default;
        Materialize((Frame)f, ref component, in context);
        return f.Set(entity, component) == SetResult.ComponentAdded;
    }
    public void Materialize(Frame frame, ref Quantum.WrappingObject result, in PrototypeMaterializationContext context = default) {
        MaterializeUser(frame, ref result, in context);
    }
  }
}
#pragma warning restore 0109
#pragma warning restore 1591
