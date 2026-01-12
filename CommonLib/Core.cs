using System;
using Microsoft.Xna.Framework; // add this first for extend Game
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
namespace CommonLib;

public class Core : Game
{
    internal static Core s_instance;

    /// <summary>
    /// Reference to the Core instance
    /// </summary>
    public static Core Instance => s_instance;

    /// <summary>
    /// Gets the graphics device manager to control the presentation of graphics
    /// </summary>
    public static GraphicsDeviceManager Graphics {get; private set;}
    
    /// <summary>
    /// Gets the graphics device used 
    /// to create graphical resources and perform primitive rendering
    /// </summary>
    public static new GraphicsDevice GraphicsDevice {get; private set;}

    /// <summary>
    /// Spritebatch for all 2d rendering
    /// </summary>
    public static SpriteBatch SpriteBatch {get; private set;}

    /// <summary>
    /// Content manager to load global assets
    /// </summary>
    public static new ContentManager Content {get; private set;}

    /// <summary>
    /// Creates a new Core instance
    /// </summary>
    public Core(string title, int width, int height, bool fullScreen, bool isMouseVisible = true)
    {
        // ensure that multiple cores are not created
        if(s_instance != null)
        {
            throw new InvalidOperationException($"Only a single core can be created");
        }

        // store reference to engine for global member access
        s_instance = this;
        
        // create new graphic device manager
        Graphics = new GraphicsDeviceManager(this);

        // set the graphics defaults
        Graphics.PreferredBackBufferHeight = height;
        Graphics.PreferredBackBufferWidth = width;
        Graphics.IsFullScreen = fullScreen;

        // apply graphic presentation changes
        Graphics.ApplyChanges();

        // set window title
        Window.Title = title;

        // set the core's content manager 
        // to a reference of the base Game's content manager
        Content = base.Content;

        // set root directory for contents
        Content.RootDirectory = "Content";

        // set mouse visibility
        IsMouseVisible = isMouseVisible;
    }

    protected override void Initialize()
    {
        base.Initialize();

        // set the core's graphic device to a reference
        // of the base Game's graphics device
        GraphicsDevice = base.GraphicsDevice;

        // create sprite batch
        SpriteBatch = new SpriteBatch(GraphicsDevice);
    }
}