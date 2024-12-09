using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using Entidades.DTOs.Imoveis;
using Entidades.Imoveis.Pai;
using Entidades.Interfaces.Imoveis;
using Entidades.Usuarios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Core.Services;

public class ImovelService : IImovelService
{
    private readonly IImovelRepository _Repository;
    private readonly Cloudinary _Cloudinary;

    public ImovelService(IImovelRepository imovelRepository, Cloudinary cloudinary)
	{
        _Repository = imovelRepository;
        _Cloudinary = cloudinary;
    }

    public async Task<ReturnImovelIdDTO> Adicionar([FromBody] Imovel imovel)
    {
        return await _Repository.Adicionar(imovel);
    }

    public async Task<string> UploadImage(IFormFile imagem, string imovelId)
    {
        Imovel imovel = BuscarImovelPorIdPrivate(imovelId);

        string fileName = imagem.FileName;

        byte[] imagemBytes;
        using (var memoryStream = new MemoryStream())
        {
            await imagem.CopyToAsync(memoryStream);
            imagemBytes = memoryStream.ToArray();
        }

        using (var memoryStream = new MemoryStream(imagemBytes))
        {
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(fileName, memoryStream)
            };
            var uploadResult = await _Cloudinary.UploadAsync(uploadParams);

            if (uploadResult.StatusCode != System.Net.HttpStatusCode.OK)
            {
                return "Erro ao carregar a imagem.";
            }

            imovel.URLsImagens.Add(uploadResult.SecureUrl.ToString());

            Editar(imovel);

            return uploadResult.SecureUrl.ToString();
        }
    }

    public async Task<List<Imovel>> Listar()
    {
        return await _Repository.Listar();
    }

    public async Task<Imovel> BuscarImovelPorId(string id)
    {
        return await _Repository.BuscarImovelPorId(id);
    }

    public async Task<List<Imovel>> BuscarImoveisPorTipo(string tipo)
    {
        return await _Repository.BuscarImoveisPorTipo(tipo);
    }

    public async Task<List<string>> BuscarURLsImagensPorId(string id)
    {
        return await _Repository.BuscarURLsImagensPorId(id);
    }

    public async Task Editar(Imovel imovelEdit)
    {
        _Repository.Editar(imovelEdit);
    }

    public async Task Remover(string id)
    {
        _Repository.Remover(id);
    }

    public async Task InicializarImoveisPreDefinidos()
    {
        _Repository.InicializarImoveisPreDefinidos();
    }

    public async Task<ReturnPrecificadorImovelDTO> PrecificarImovel(PrecificadorImovelDTO imovel)
    {
        return await _Repository.PrecificarImovel(imovel);
    }

    private Imovel BuscarImovelPorIdPrivate(string id)
    {
        return _Repository.BuscarImovelPorIdPrivate(id);
    }
}