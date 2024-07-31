namespace ProofIdentity.Application.DTOs;
public record RegisterBasicUserDto
(
    string NameCompleto,
    DateTime DateNascimento,
    string Cpf,
    string Email,
    string Password,
    string UserName
);