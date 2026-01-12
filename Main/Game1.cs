using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using CommonLib;

namespace Main;

public class Game1 : Core
{
    private Texture2D _logo;

    public Game1() : base("Dungeon Slime", 1280, 720, false)
    {

    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        // TODO: use this.Content to load your game content here
        _logo = Content.Load<Texture2D>("assets/images/logo");
        base.LoadContent();
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        // TODO: Add your drawing code here

        GraphicsDevice.Clear(Color.CornflowerBlue);

        Rectangle logoIcon = new(0, 0, 128, 128);
        Rectangle logoWord = new(150, 34, 458, 58);

        SpriteBatch.Begin(sortMode: SpriteSortMode.FrontToBack);
        // icon
        SpriteBatch.Draw(
            _logo, // texture2D
            new Vector2( // position, middle of the screen
                Window.ClientBounds.Width,
                Window.ClientBounds.Height
            ) * 0.5f,
            logoIcon,   // rectangle
            Color.White * 1.0f, // color masking & opacity
            MathHelper.ToRadians(0),   // rotation
            new Vector2( // origin, middle of original image
                logoIcon.Width,
                logoIcon.Height
            ) * 0.5f, 
            1.0f,   // scale -> float | vector2d(x, y)
            SpriteEffects.None, // effects -> None, FlipHorizontally, FlipVertically
            1.0f    // layerDepth
            );
        SpriteBatch.Draw(
            _logo, // texture2D
            new Vector2( // position, middle of the screen
                Window.ClientBounds.Width,
                Window.ClientBounds.Height
            ) * 0.5f,
            logoWord,   // rectangle
            Color.White * 1.0f, // color masking & opacity
            MathHelper.ToRadians(0),   // rotation
            new Vector2( // origin, middle of original image
                logoWord.Width,
                logoWord.Height
            ) * 0.5f, 
            1.0f,   // scale -> float | vector2d(x, y)
            SpriteEffects.None, // effects -> None, FlipHorizontally, FlipVertically
            0.0f    // layerDepth
            );
        SpriteBatch.End();

        base.Draw(gameTime);
    }
}
