using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using CalculationEngine.Core;

namespace Client.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public string Expression
        {
            get;
            set;
        }

        public string Result { get; set; }
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
          
        }

        public void OnPost()
        {
            Expression = Request.Form[nameof(Expression)];
            if (string.IsNullOrEmpty(Expression)) return;
            _logger.LogInformation($"Calculation Engine called to evaluate an expression: {Expression}");
            var evaluator = new Evaluator();
            try
            {
                var result = evaluator.Evaluate(Expression);
                _logger.LogInformation($"Result for '{Expression}' is {result}");
                Result = $"Result for '{Expression}' is {result}";
            }
            catch(Exception ex)
            {
                _logger.LogError($"Calculation Engine Failed for '{Expression}'. Error message: {ex.Message}");
                Result = ex.Message;
            }
           
        }
    }
}
