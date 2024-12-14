namespace Back_End_WebAPI.Data
{
    public static class Constants
    {
        public static class HttpResponses
        {
            public const string msg1 = "Sunt deja examene programate in acea perioada";
            public const string msg2 = "Timpul de incepere nu este in format corect";
            public const string msg3 = "Profesorul participa deja la un alt examen";
            public const string msg4 = "Asistentul participa deja la un alt examen";
            public const string msg5 = "Examen adaugat";
            public const string msg6 = "Cerere deja aprobata sau respinsa";
            public const string msg7 = "Deja este un examen programat pentru acea cerere";
            public const string msg8 = "Examenele sunt prea aproape una, modifica data";
            public const string msg9 = "Sunt deja examene programate in acea perioada";
            public const string msg10 = "Exista deja un examen programat pentru aceasta disciplina";
            public const string msg11 = "Cerere trimisa";
            public const string msg12 = "Email invalid";
            public const string msg13 = "Parola invalida";
            public const string msg14 = "Rolul utilizatorul nu a fost gasit";
            public const string msg15 = "Locatie adaugata";
            public const string msg16 = "Subiect adaugat";
            public const string msg17 = "Parola este prea slaba, minim 5 caractere";
            public const string msg18 = "Utilizator adaugat";
        }
        public static class RequestStatus
        {
            public const string Pending = "Pending";
            public const string Accepted = "Accepted";
            public const string Rejected = "Rejected";
        }
        public static class UserRoles
        {
            public const string Student = "Student";
            public const string GroupLeader = "GroupLeader";
            public const string Professor = "Professor";
            public const string Assistant = "Assistant";
        }
    }
}
