﻿using System.Collections;
using ApiEstudo.Models;

namespace ApiEstudo.DTOs.Mappings
{
    public static class CategoriaDTOMappingExtensions
    {
        public static CategoriaDTO? ToCategoriaDTO(this Categoria categoria)
        {
            if (categoria == null)
                return null;

            return new CategoriaDTO()
            {
                CategoriaId = categoria.CategoriaId,
                Nome = categoria.Nome,
                ImagemUrl = categoria.ImagemUrl
            };
        }

        public static Categoria? ToCategoria(this CategoriaDTO categoriaDTO)
        {
            if (categoriaDTO == null)
                return null;


            return new Categoria()
            {
                CategoriaId = categoriaDTO.CategoriaId,
                Nome = categoriaDTO.Nome,
                ImagemUrl = categoriaDTO.ImagemUrl
            };
        }

        public static IEnumerable<CategoriaDTO> ToCategoriaDTOList(this IEnumerable<Categoria> categorias)
        {
            if (categorias == null || !categorias.Any())
            {
                return new List<CategoriaDTO>();
            }
            
            return categorias.Select(c => new CategoriaDTO()
            {
                CategoriaId = c.CategoriaId,
                Nome = c.Nome,
                ImagemUrl = c.ImagemUrl
            }).ToList();
        }
    }
}
