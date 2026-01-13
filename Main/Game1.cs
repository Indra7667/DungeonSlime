using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using CommonLib;
using CommonLib.Graphics;

namespace Main;

public class Game1 : Core
{
    private Sprite _slime;
    private Sprite _bat;

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

        // create texture atlas from entity xml
        TextureAtlas atlas = TextureAtlas.FromFile(Content, "assets/images/atlas/entities-definition.xml");

        // make slime sprite from atlas' region
        _slime = atlas.CreateSprite("slime");
        _slime.Rescale(4.0f);

        // make bat sprite from atlas' region
        _bat = atlas.CreateSprite("bat");
        _bat.Rescale(4.0f);

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
            Vector2.Zero
        );

        // dar the bat
        _bat.Draw(
            SpriteBatch,
            new Vector2(_slime.Width*1.5f, 0) // half a slime next to the slime
        );
        SpriteBatch.End();

        base.Draw(gameTime);
    }
}
