using System.Threading.Tasks;
using SiliconStudio.Core.Mathematics;
using SiliconStudio.Paradox;
using SiliconStudio.Paradox.Effects;
using SiliconStudio.Paradox.Graphics;

namespace Newt
{
    public class NewtGame : Game
    {
        public NewtGame()
        {
            // Target 9.1 profile by default
            GraphicsDeviceManager.PreferredGraphicsProfile = new[] { GraphicsProfile.Level_9_1 };
        }

        protected override async Task LoadContent()
        {
            await base.LoadContent();

            CreatePipeline();

            // Add custom game init at load time here
            // ...
           
            // Add a custom script
            Script.Add(GameScript1);

            await Asset.LoadAsync<SpriteGroup>("nol");

        }

        private void CreatePipeline()
        {
            // Setup the default rendering pipeline
            RenderSystem.Pipeline.Renderers.Add(new CameraSetter(Services));
            RenderSystem.Pipeline.Renderers.Add(new RenderTargetSetter(Services) { ClearColor = Color.CornflowerBlue });
            RenderSystem.Pipeline.Renderers.Add(new ModelRenderer(Services, "NewtEffectMain"));
            RenderSystem.Pipeline.Renderers.Add(new SpriteRenderer(Services));
            RenderSystem.Pipeline.Renderers.Add(new UIRenderer(Services));
        }

        private async Task GameScript1()
        {
            while (IsRunning)
            {
                // Wait next rendering frame
                await Script.NextFrame();

                // Add custom code to run every frame here (move entity...etc.)
                // ...
            }
        }
    }
}
