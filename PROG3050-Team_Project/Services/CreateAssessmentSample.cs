using System;
using Google.Api.Gax.ResourceNames;
using Google.Cloud.RecaptchaEnterprise.V1;

public class CreateAssessmentSample
{
    public void createAssessment(string projectID = "prog3050gamevoid-1727964316142", string recaptchaKey = "6Ld32FcqAAAAANrQRUMWVjmxaJ-QCmXpBiY96LQR", string token = "action-token", string recaptchaAction = "action-name")
    {
        // Create the reCAPTCHA client.
        // TODO: Cache the client generation code (recommended) or call client.close() before exiting the method.
        RecaptchaEnterpriseServiceClient client = RecaptchaEnterpriseServiceClient.Create();

        ProjectName projectName = new ProjectName(projectID);

        // Build the assessment request.
        CreateAssessmentRequest createAssessmentRequest = new CreateAssessmentRequest()
        {
            Assessment = new Assessment()
            {
                // Set the properties of the event to be tracked.
                Event = new Event()
                {
                    SiteKey = recaptchaKey,
                    Token = token,
                    ExpectedAction = recaptchaAction
                },
            },
            ParentAsProjectName = projectName
        };

        Assessment response = client.CreateAssessment(createAssessmentRequest);

        // Check if the token is valid.
        if (response.TokenProperties.Valid == false)
        {
            System.Console.WriteLine("The CreateAssessment call failed because the token was: " +
                response.TokenProperties.InvalidReason.ToString());
            return;
        }

        // Check if the expected action was executed.
        if (response.TokenProperties.Action != recaptchaAction)
        {
            System.Console.WriteLine("The action attribute in reCAPTCHA tag is: " +
                response.TokenProperties.Action.ToString());
            System.Console.WriteLine("The action attribute in the reCAPTCHA tag does not " +
                "match the action you are expecting to score");
            return;
        }

        // Get the risk score and the reason(s).
        // For more information on interpreting the assessment, see:
        // https://cloud.google.com/recaptcha-enterprise/docs/interpret-assessment
        System.Console.WriteLine("The reCAPTCHA score is: " + ((decimal)response.RiskAnalysis.Score));

        foreach (RiskAnalysis.Types.ClassificationReason reason in response.RiskAnalysis.Reasons)
        {
            System.Console.WriteLine(reason.ToString());
        }
    }

    public static void Main(string[] args)
    {
        new CreateAssessmentSample().createAssessment();
    }
}