using Microsoft.AspNetCore.Mvc;

internal class ErrorsByFieldResponses : IActionResult
{
    public IEnumerable<ErrorsByField>? Errors { get; set; }

    public ErrorsByFieldResponses(IEnumerable<ErrorsByField>? errors = null)
    {
        Errors = errors;
    }

    public async Task ExecuteResultAsync(ActionContext context)
    {

        var objectResult = new ObjectResult(Errors)
        {
            StatusCode = StatusCodes.Status400BadRequest
        };

        await objectResult.ExecuteResultAsync(context);
        
    }
}

internal class ErrorsByField
{
    public string? Field { get; set; }

    public IEnumerable<string> ? Messages { get; set; }
}