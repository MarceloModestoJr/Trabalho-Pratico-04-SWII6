﻿namespace WebAPI.Models
{
    public class Atividade
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataEntrega { get; set; }
        public ushort Prioridade { get; set; }
    }
}
