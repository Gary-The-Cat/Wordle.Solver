using Impulse.SharedFramework.Application;
using Impulse.SharedFramework.Plugin;
using Impulse.SharedFramework.Services;
using System.Runtime.Versioning;
using System.Threading.Tasks;
using WordleSolver.Plugin.UIElements.Screens.Solver;

namespace WordleSolver.Plugin;
public class WordleSolverPlugin : IPlugin
{
    private IRibbonService ribbonService;
    private IDocumentService documentService;

    public IDashboardProvider Dashboard { get; set; }

    private WordleSolverPlugin(IRibbonService ribbonService, IDocumentService documentService)
    {
        this.ribbonService = ribbonService;
        this.documentService = documentService;
    }

    [RequiresPreviewFeatures]
    public static IPlugin Create(IRibbonService ribbonService, IDocumentService documentService)
    {
        return new WordleSolverPlugin(ribbonService, documentService); 
    }

    public Task Initialize()
    {
        // Load the ribbon button here.
        this.ribbonService.AddButton(new Impulse.SharedFramework.Ribbon.RibbonButtonViewModel()
        {
            Title = "Wrodle Solver",
            Id = "Developer.Debug.Demos.WordleSolver",
            EnabledIcon = "pack://application:,,,/Impulse.Dashboard;Component/Icons/Export/Bat.png",
            DisabledIcon = "pack://application:,,,/Impulse.Dashboard;Component/Icons/Export/Bat_GS.png",
            IsEnabled = true,
            Callback = OpenSolvleDemo
        });

        return Task.CompletedTask;
    }

    private void OpenSolvleDemo()
    {
        var document = new SolverInputTabViewModel();
        this.documentService.OpenDocument(document);
    }

    public Task OnClose()
    {
        return Task.CompletedTask;
    }
}
