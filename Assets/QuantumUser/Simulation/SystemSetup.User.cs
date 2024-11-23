﻿using Quantum.Core;
using System.Collections.Generic;

namespace Quantum {
    public static partial class DeterministicSystemSetup {
        static partial void AddSystemsUser(ICollection<SystemBase> systems, RuntimeConfig gameConfig, SimulationConfig simulationConfig, SystemsConfig systemsConfig) {
            // The system collection is already filled with systems coming from the SystemsConfig.
            // Add or remove systems to the collection: systems.Add(new SystemFoo());

            // Remove the default systems
            systems.Clear();

            systems.Add(new EntityPrototypeSystem());
            systems.Add(new PlayerConnectedSystem());
            systems.Add(new MvLCullingSystem());
            systems.Add(new GameLogicSystem());
            systems.Add(new InteractionSystemPhysicsQuerySystem());
            systems.Add(new PhysicsSystem2D());

            systems.Add(
                new StartDisabledSystemGroup("gameplay",
                    new GenericMoverSystem(),
                    new SpinnerSystem(),
                    new MovingPlatformSystem(),
                    new EnemySystem(),
                    new PhysicsObjectSystem(),
                    new InteractionSystem(),
                    new GoombaSystem(),
                    new KoopaSystem(),
                    new BobombSystem(),
                    new PiranhaPlantSystem(),
                    new BulletBillSystem(),
                    new BooSystem(),
                    new ProjectileSystem(),
                    new PowerupSystem(),
                    new BlockBumpSystem(),
                    new MarioPlayerSystem(),
                    new CoinSystem(),
                    new WrappingObjectSystem(),
                    new BigStarSystem(),
                    new HoldableObjectSystem(),
                    new IceBlockSystem(),
                    new CameraSystem()
                )
            );
            // Signals only... can't be in a group.
            systems.Add(new StageSystem());
            systems.Add(new LiquidSystem());
            systems.Add(new BreakableObjectSystem());
            systems.Add(new MarioBrosPlatformSystem());
            systems.Add(new EnterablePipeSystem());
        }
    }
}