using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;

namespace Wotan.Client
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        // Set the 3D model to draw.
        Model myModel;

        // The aspect ratio determines how to scale 3d to 2d projection.
        float aspectRatio;

        // Set the position of the model in world space, and set the rotation.
        Vector3 modelPosition = Vector3.Zero;
        float modelRotation = 0.0f;

        // Set the position of the camera in world space, for our view matrix.
        Vector3 cameraPosition = new Vector3(0.0f, 50.0f, 5000.0f);

        // Set the velocity of the model, applied each frame to the model's position.
        Vector3 modelVelocity = Vector3.Zero;



        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            myModel = Content.Load<Model>("Models\\p1_wedge");
            aspectRatio = graphics.GraphicsDevice.Viewport.Width / graphics.GraphicsDevice.Viewport.Height;

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // Get some input.
            UpdateInput();

            // Add velocity to the current position.
            modelPosition += modelVelocity;

            // Bleed off velocity over time.
            modelVelocity *= 0.95f;


            //modelRotation += (float)gameTime.ElapsedGameTime.TotalMilliseconds * MathHelper.ToRadians(0.1f);

            base.Update(gameTime);
        }


        protected void UpdateInput()
        {
            KeyboardState currentState = Keyboard.GetState(PlayerIndex.One);
            foreach(Keys k in currentState.GetPressedKeys())
            {
                switch(k)
                {
                    case Keys.Left:
                        modelRotation += 0.10f;
                        break;
                    case Keys.Right:
                        modelRotation -= 0.10f;
                        break;
                    case Keys.Up:
                        Vector3 modelVelocityAdd = Vector3.Zero;
                        modelVelocityAdd.X = -(float)Math.Sin(modelRotation);
                        modelVelocityAdd.Z = -(float)Math.Cos(modelRotation);
                        modelVelocityAdd *= 10;
                        modelVelocity += modelVelocityAdd;
                        break;

                }
            }

//            // Get the game pad state.
//            GamePadState currentState = GamePad.GetState(PlayerIndex.One);
//            if (currentState.IsConnected)
//            {
//                // Rotate the model using the left thumbstick, and scale it down.
//                modelRotation -= currentState.ThumbSticks.Left.X * 0.10f;
//
//                // Create some velocity if the right trigger is down.
//                Vector3 modelVelocityAdd = Vector3.Zero;
//
//                // Find out what direction we should be thrusting, using rotation.
//                modelVelocityAdd.X = -(float)Math.Sin(modelRotation);
//                modelVelocityAdd.Z = -(float)Math.Cos(modelRotation);
//
//                // Now scale our direction by how hard the trigger is down.
//                modelVelocityAdd *= currentState.Triggers.Right;
//
//                // Finally, add this vector to our velocity.
//                modelVelocity += modelVelocityAdd;
//
//                GamePad.SetVibration(PlayerIndex.One, currentState.Triggers.Right,
//                    currentState.Triggers.Right);
//
//
//                // In case you get lost, press A to warp back to the center.
//                if (currentState.Buttons.A == ButtonState.Pressed)
//                {
//                    modelPosition = Vector3.Zero;
//                    modelVelocity = Vector3.Zero;
//                    modelRotation = 0.0f;
//                }
//            }
        }



        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            graphics.GraphicsDevice.Clear(Color.Black);
            const float FarPlaneDistance = 1000000.0f;

            // Copy any parent transforms.
            Matrix[] transforms = new Matrix[myModel.Bones.Count];
            myModel.CopyAbsoluteBoneTransformsTo(transforms);

            // Draw the model. A model can have multiple meshes, so loop.
            foreach (ModelMesh mesh in myModel.Meshes)
            {
                // This is where the mesh orientation is set, as well as our camera and projection.
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.EnableDefaultLighting();
                    effect.World = transforms[mesh.ParentBone.Index] * Matrix.CreateRotationY(modelRotation) * Matrix.CreateTranslation(modelPosition);
                    effect.View = Matrix.CreateLookAt(cameraPosition, Vector3.Zero, Vector3.Up);
                    effect.Projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45.0f),
                        aspectRatio, 1.0f, FarPlaneDistance);
                }
                // Draw the mesh, using the effects set above.
                mesh.Draw();
            }


            base.Draw(gameTime);
        }
    }
}
