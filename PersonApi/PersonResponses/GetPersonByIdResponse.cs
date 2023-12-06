using Application.DTO;

namespace PersonApi.PersonResponses
{
    public record GetPersonByIdResponse
    (
        string message,
        PersonDTO PersonDTO
        );
}
