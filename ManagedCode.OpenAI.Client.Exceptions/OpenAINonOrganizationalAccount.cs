using System.Net;

namespace ManagedCode.OpenAI.Client.Exceptions;

public class OpenAINonOrganizationalAccount: OpenAIClientException
{
    public OpenAINonOrganizationalAccount() : base(
        "You must be a member of an organization to use the API. Contact us to get added to a new organization or ask your organization manager to invite you to an organization.",
        null,
        HttpStatusCode.Unauthorized)
    {
    }
}