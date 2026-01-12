using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using CommonLib;
using CommonLib.Graphics;

namespace Main;

public class Game1 : Core
{
    private TextureRegion _slime;
    private TextureRegion _bat;

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

        // load entity atlas
        Texture2D entityAtlas = Content.Load<Texture2D>("assets/images/atlas/entities");

        // create texture atlas from loaded atlas
        TextureAtlas atlas = new TextureAtlas(entityAtlas);

        // add slime's region
        atlas.AddRegion("slime", 0, 0, 20, 20);
        // add bat's region
        atlas.AddRegion("bat", 20, 0, 20, 20);

        // get slime region from atlas
        _slime = atlas.GetRegion("slime");

        // get bat region from atlas
        _bat = atlas.GetRegion("bat");

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

        // clear back buffer
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // begin sprite batch
        SpriteBatch.Begin(samplerState: SamplerState.PointClamp, sortMode: SpriteSortMode.FrontToBack);

        // draw the slime
        _slime.Draw(
            SpriteBatch,
            Vector2.Zero,
            Color.White,
            0.0f,
            Vector2.One,
            4.0f, // scale by 4
            SpriteEffects.None,
            0.0f
            );

        // dar the bat
        _bat.Draw(
            SpriteBatch,
            new Vector2(_slime.Width * 4.0f + 10, 0), // 10 pixel next to the slime
            Color.White,
            0.0f,
            Vector2.One,
            4.0f,  // scale by 4
            SpriteEffects.None,
            1.0f
            );
        SpriteBatch.End();

        base.Draw(gameTime);
    }
}
