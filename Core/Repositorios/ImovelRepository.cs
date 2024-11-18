using Entidades.Imoveis.Filho;
using Entidades.Imoveis.Pai;
using Entidades.Interfaces.Imoveis;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System.Security.Cryptography;

namespace Core.Repositorios;

public class ImovelRepository : IImovelRepository
{
    private readonly IMongoCollection<Imovel> _Imoveis;

    public ImovelRepository(IMongoDatabase database)
    {
        try
        {
            _Imoveis = database.GetCollection<Imovel>("Imoveis");
        }
        catch (MongoBulkWriteException ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task Adicionar([FromBody] Imovel imovel)
    {
        try
        {
            await _Imoveis.InsertOneAsync(imovel);
        }

        catch (MongoBulkWriteException ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<List<Imovel>> Listar()
    {
        try
        {
            return await _Imoveis.Find(imovel => true).ToListAsync();
        }
        catch (MongoBulkWriteException ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<Imovel> BuscarImovelPorId(string id)
    {
        try
        {
            return await _Imoveis.Find<Imovel>(imovel => imovel.Id == id).FirstOrDefaultAsync();
        }
        catch (MongoBulkWriteException ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<List<Imovel>> BuscarImoveisPorTipo(string tipo)
    {
        try
        {
            return await _Imoveis.Find<Imovel>(imovel => imovel.Tipo == tipo).ToListAsync();
        }
        catch (MongoBulkWriteException ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<List<string>> BuscarURLsImagensPorId(string id)
    {
        try
        {
            Imovel i = _Imoveis.Find<Imovel>(imovel => imovel.Id == id).FirstOrDefault();

            return i.URLsImagens;
        }
        catch (MongoBulkWriteException ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task Editar(Imovel imovel)
    {
        try
        {
            await _Imoveis.ReplaceOneAsync(imovel => imovel.Id == imovel.Id, imovel);
        }
        catch (MongoBulkWriteException ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task Remover(string id)
    {
        try
        {
            await _Imoveis.DeleteOneAsync(imovel => imovel.Id == id);
        }
        catch (MongoBulkWriteException ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public static void AdicionarImoveisPreDefinidos()
    {
        List<Imovel> imoveisPreDefinidos;
        {
            new Apartamento
            {
                Id = null,
                Tipo = "Apartamento",
                Area = 66.0,
                Preco = 475000.00,
                Anos = 2,
                CEP = "12900-430",
                Rua = "Rua Dom Aguirre",
                Numero = 329,
                Bairro = "Centro",
                Cidade = "Bragança Paulista",
                UnidadeFederativa = "SP",
                Endereco = "Rua Dom Aguirre, 329, Centro, Bragança Paulista, SP - 12900-430",
                URLsImagens = new List<string>
                {
                    "http://exemplo.com/imagem1.jpg",
                    "http://exemplo.com/imagem2.jpg",
                    "http://exemplo.com/imagem3.jpg"
                },
                Descricao = "Oportunidade Única! Loft com 2 Suítes no Coração de Bragança Paulista\r\n\r\nVocê não pode perder essa incrível chance de adquirir um loft com 2 suítes no centro de Bragança Paulista! Com toda a comodidade que a localização privilegiada pode oferecer, esse loft é perfeito para quem busca conforto e estilo de vida.\r\n\r\nCaracterísticas do Imóvel:\r\n\r\n2 Suítes com Varandas nos Quartos.\r\nMóveis Planejados de Excelente Qualidade e Bom Gosto.\r\nCharmosa Varanda Gourmet com Vista da Cidade.\r\nEspaço Gourmet no Condomínio, um Charme à Parte.\r\nTotal de 2 Banheiros para Conveniência.\r\nDesign Moderno e Funcional.\r\nLocalização Privilegiada:\r\n\r\nNo Coração de Bragança Paulista.\r\nFacilidade de Acesso a Comércio e Serviços.\r\nDesfrute do Melhor da Cidade ao Seu Redor.\r\nPreço Imperdível: R$ 475.000,00\r\n\r\nValor Abaixo do Mercado.\r\nUma Oportunidade Única de Investimento.\r\nNão deixe essa oportunidade escapar! Entre em contato conosco hoje mesmo para agendar uma visita e conhecer pessoalmente esse loft incrível. A qualidade de vida que você merece está a apenas um passo de distância.",
                AreasComuns = new List<string>
                {
                    "Churrasqueira (parrilla)",
                    "Solarium",
                    "Varanda",
                    "Varanda Gourmet",
                    "Interfone"
                },
                Quartos = 2,
                Suites = 2,
                Banheiros = 2,
                Vagas = 1,
                Andar = 3
            };
            new Apartamento
            {
                Id = null,
                Tipo = "Apartamento",
                Area = 70.0,
                Preco = 490000.00,
                Anos = 3,
                CEP = "14000-000",
                Rua = "Avenida Paulista",
                Numero = 1000,
                Bairro = "Bela Vista",
                Cidade = "São Paulo",
                UnidadeFederativa = "SP",
                Endereco = "Avenida Paulista, 1000, Bela Vista, São Paulo, SP - 14000-000",
                URLsImagens = new List<string> { "http://exemplo.com/imagem4.jpg", "http://exemplo.com/imagem5.jpg", "http://exemplo.com/imagem6.jpg" },
                Descricao = "Moderno Apartamento de 3 Quartos na Avenida Paulista. Localização Imbatível, próximo a tudo o que você precisa!",
                AreasComuns = new List<string> { "Piscina", "Academia", "Salão de Festas", "Playground", "Quadra Poliesportiva" },
                Quartos = 3,
                Suites = 1,
                Banheiros = 2,
                Vagas = 2,
                Andar = 10
            };
            new Apartamento
            {
                Id = null,
                Tipo = "Apartamento",
                Area = 85.0,
                Preco = 530000.00,
                Anos = 5,
                CEP = "15000-100",
                Rua = "Rua Oscar Freire",
                Numero = 200,
                Bairro = "Jardins",
                Cidade = "São Paulo",
                UnidadeFederativa = "SP",
                Endereco = "Rua Oscar Freire, 200, Jardins, São Paulo, SP - 15000-100",
                URLsImagens = new List<string> { "http://exemplo.com/imagem7.jpg", "http://exemplo.com/imagem8.jpg", "http://exemplo.com/imagem9.jpg" },
                Descricao = "Apartamento Luxuoso nos Jardins, com 2 Suítes e Vista para a Cidade. Exclusividade e Conforto em cada detalhe.",
                AreasComuns = new List<string> { "Sauna", "Piscina Aquecida", "Sala de Jogos", "Espaço Gourmet", "Cinema" },
                Quartos = 3,
                Suites = 2,
                Banheiros = 3,
                Vagas = 3,
                Andar = 5
            };
            new Apartamento
            {
                Id = null,
                Tipo = "Apartamento",
                Area = 60.0,
                Preco = 450000.00,
                Anos = 1,
                CEP = "16000-200",
                Rua = "Avenida Ipiranga",
                Numero = 300,
                Bairro = "Centro",
                Cidade = "Porto Alegre",
                UnidadeFederativa = "RS",
                Endereco = "Avenida Ipiranga, 300, Centro, Porto Alegre, RS - 16000-200",
                URLsImagens = new List<string> { "http://exemplo.com/imagem10.jpg", "http://exemplo.com/imagem11.jpg", "http://exemplo.com/imagem12.jpg" },
                Descricao = "Apartamento Novo no Centro de Porto Alegre, com 1 Suíte e Área de Lazer Completa. Perfeito para Jovens Casais.",
                AreasComuns = new List<string> { "Piscina", "Espaço Fitness", "Salão de Festas", "Churrasqueira", "Brinquedoteca" },
                Quartos = 2,
                Suites = 1,
                Banheiros = 2,
                Vagas = 1,
                Andar = 8
            };
            new Apartamento
            {
                Id = null,
                Tipo = "Apartamento",
                Area = 75.0,
                Preco = 510000.00,
                Anos = 4,
                CEP = "12000-300",
                Rua = "Rua das Flores",
                Numero = 150,
                Bairro = "Jardim das Rosas",
                Cidade = "Campinas",
                UnidadeFederativa = "SP",
                Endereco = "Rua das Flores, 150, Jardim das Rosas, Campinas, SP - 12000-300",
                URLsImagens = new List<string> { "http://exemplo.com/imagem13.jpg", "http://exemplo.com/imagem14.jpg", "http://exemplo.com/imagem15.jpg" },
                Descricao = "Encantador Apartamento no Jardim das Rosas, com 3 Quartos e Varanda Gourmet. Ideal para Famílias que Buscam Conforto e Estilo.",
                AreasComuns = new List<string> { "Piscina", "Salão de Festas", "Academia", "Brinquedoteca", "Espaço Pet" },
                Quartos = 3,
                Suites = 1,
                Banheiros = 2,
                Vagas = 2,
                Andar = 6
            };

            new Casa
            {
                Id = null,
                Tipo = "Casa",
                Area = 120.0,
                Preco = 750000.00,
                Anos = 8,
                CEP = "18000-400",
                Rua = "Rua dos Girassóis",
                Numero = 250,
                Bairro = "Jardim Primavera",
                Cidade = "Sorocaba",
                UnidadeFederativa = "SP",
                Endereco = "Rua dos Girassóis, 250, Jardim Primavera, Sorocaba, SP - 18000-400",
                URLsImagens = new List<string> { "http://exemplo.com/imagem16.jpg", "http://exemplo.com/imagem17.jpg", "http://exemplo.com/imagem18.jpg" },
                Descricao = "Linda Casa com 3 Quartos e Área Gourmet no Jardim Primavera. Conforto e Estilo em um Só Lugar.",
                AreasComuns = new List<string> { "Piscina", "Playground", "Salão de Festas", "Espaço Zen", "Churrasqueira" },
                Quartos = 3,
                Suites = 1,
                Banheiros = 2,
                Vagas = 2
            };
            new Casa
            {
                Id = null,
                Tipo = "Casa",
                Area = 100.0,
                Preco = 680000.00,
                Anos = 6,
                CEP = "17000-500",
                Rua = "Avenida das Américas",
                Numero = 350,
                Bairro = "Vila Olímpia",
                Cidade = "Rio de Janeiro",
                UnidadeFederativa = "RJ",
                Endereco = "Avenida das Américas, 350, Vila Olímpia, Rio de Janeiro, RJ - 17000-500",
                URLsImagens = new List<string> { "http://exemplo.com/imagem19.jpg", "http://exemplo.com/imagem20.jpg", "http://exemplo.com/imagem21.jpg" },
                Descricao = "Casa Moderno e Confortável na Vila Olímpia, com 2 Quartos e Ampla Varanda. Excelente Localização.",
                AreasComuns = new List<string> { "Piscina", "Academia", "Sala de Jogos", "Parque Infantil", "Churrasqueira" },
                Quartos = 2,
                Suites = 1,
                Banheiros = 2,
                Vagas = 1
            };
            new Casa
            {
                Id = null,
                Tipo = "Casa",
                Area = 95.0,
                Preco = 620000.00,
                Anos = 10,
                CEP = "13000-600",
                Rua = "Rua das Palmeiras",
                Numero = 450,
                Bairro = "Jardim Botânico",
                Cidade = "Curitiba",
                UnidadeFederativa = "PR",
                Endereco = "Rua das Palmeiras, 450, Jardim Botânico, Curitiba, PR - 13000-600",
                URLsImagens = new List<string> { "http://exemplo.com/imagem22.jpg", "http://exemplo.com/imagem23.jpg", "http://exemplo.com/imagem24.jpg" },
                Descricao = "Espaçosa Casa com 3 Quartos no Jardim Botânico, Curitiba. Área Gourmet e Condomínio Completo.",
                AreasComuns = new List<string> { "Piscina", "Salão de Festas", "Espaço Fitness", "Área Verde", "Brinquedoteca" },
                Quartos = 3,
                Suites = 1,
                Banheiros = 2,
                Vagas = 2
            };
            new Casa
            {
                Id = null,
                Tipo = "Casa",
                Area = 85.0,
                Preco = 580000.00,
                Anos = 4,
                CEP = "14000-700",
                Rua = "Avenida do Café",
                Numero = 550,
                Bairro = "Jardim do Lago",
                Cidade = "Ribeirão Preto",
                UnidadeFederativa = "SP",
                Endereco = "Avenida do Café, 550, Jardim do Lago, Ribeirão Preto, SP - 14000-700",
                URLsImagens = new List<string> { "http://exemplo.com/imagem25.jpg", "http://exemplo.com/imagem26.jpg", "http://exemplo.com/imagem27.jpg" },
                Descricao = "Aconchegante Casa com 2 Quartos e Vista para o Lago. Localização Tranquila e Charmosa.",
                AreasComuns = new List<string> { "Piscina", "Sala de Jogos", "Playground", "Churrasqueira", "Salão de Festas" },
                Quartos = 2,
                Suites = 1,
                Banheiros = 2,
                Vagas = 1
            };
            new Casa
            {
                Id = null,
                Tipo = "Casa",
                Area = 105.0,
                Preco = 640000.00,
                Anos = 7,
                CEP = "15000-800",
                Rua = "Rua do Sol",
                Numero = 650,
                Bairro = "Centro",
                Cidade = "Fortaleza",
                UnidadeFederativa = "CE",
                Endereco = "Rua do Sol, 650, Centro, Fortaleza, CE - 15000-800",
                URLsImagens = new List<string> { "http://exemplo.com/imagem28.jpg", "http://exemplo.com/imagem29.jpg", "http://exemplo.com/imagem30.jpg" },
                Descricao = "Casa de 3 Quartos no Centro de Fortaleza, com Área Gourmet e Piscina. Conforto e Modernidade.",
                AreasComuns = new List<string> { "Piscina", "Espaço Gourmet", "Academia", "Salão de Festas", "Área de Lazer" },
                Quartos = 3,
                Suites = 2,
                Banheiros = 3,
                Vagas = 2
            };

            new Comercial
            {
                Id = null,
                Tipo = "Comercial",
                Area = 250.0,
                Preco = 1500000.00,
                Anos = 10,
                CEP = "11000-100",
                Rua = "Avenida Central",
                Numero = 100,
                Bairro = "Centro",
                Cidade = "São Paulo",
                UnidadeFederativa = "SP",
                Endereco = "Avenida Central, 100, Centro, São Paulo, SP - 11000-100",
                URLsImagens = new List<string> { "http://exemplo.com/comercial1.jpg", "http://exemplo.com/comercial2.jpg", "http://exemplo.com/comercial3.jpg" },
                Descricao = "Amplo espaço comercial no coração de São Paulo, ideal para escritórios ou lojas de grande porte.",
                AreasComuns = new List<string> { "Estacionamento", "Recepção", "Sala de Reuniões", "Segurança 24h", "Elevador" },
                Banheiros = 4,
                Vagas = 10,
                TipoNegocio = "Escritório"
            };
            new Comercial
            {
                Id = null,
                Tipo = "Comercial",
                Area = 150.0,
                Preco = 900000.00,
                Anos = 5,
                CEP = "12000-200",
                Rua = "Rua das Flores",
                Numero = 200,
                Bairro = "Jardim Primavera",
                Cidade = "Campinas",
                UnidadeFederativa = "SP",
                Endereco = "Rua das Flores, 200, Jardim Primavera, Campinas, SP - 12000-200",
                URLsImagens = new List<string> { "http://exemplo.com/comercial4.jpg", "http://exemplo.com/comercial5.jpg", "http://exemplo.com/comercial6.jpg" },
                Descricao = "Espaço comercial moderno em Campinas, perfeito para lojas ou pequenas empresas.",
                AreasComuns = new List<string> { "Estacionamento", "Recepção", "Segurança 24h", "Área de Carga e Descarga", "Sistema de Vigilância" },
                Banheiros = 2,
                Vagas = 5,
                TipoNegocio = "Loja"
            };
            new Comercial
            {
                Id = null,
                Tipo = "Comercial",
                Area = 300.0,
                Preco = 2000000.00,
                Anos = 15,
                CEP = "13000-300",
                Rua = "Avenida das Américas",
                Numero = 300,
                Bairro = "Vila Olímpia",
                Cidade = "Rio de Janeiro",
                UnidadeFederativa = "RJ",
                Endereco = "Avenida das Américas, 300, Vila Olímpia, Rio de Janeiro, RJ - 13000-300",
                URLsImagens = new List<string> { "http://exemplo.com/comercial7.jpg", "http://exemplo.com/comercial8.jpg", "http://exemplo.com/comercial9.jpg" },
                Descricao = "Grande espaço comercial na Vila Olímpia, ideal para galpões ou centros de distribuição.",
                AreasComuns = new List<string> { "Estacionamento", "Área de Carga e Descarga", "Sistema de Vigilância", "Segurança 24h", "Área de Escritório" },
                Banheiros = 6,
                Vagas = 15,
                TipoNegocio = "Galpão"
            };
            new Comercial
            {
                Id = null,
                Tipo = "Comercial",
                Area = 180.0,
                Preco = 1200000.00,
                Anos = 8,
                CEP = "14000-400",
                Rua = "Rua dos Pinheiros",
                Numero = 400,
                Bairro = "Jardim Botânico",
                Cidade = "Curitiba",
                UnidadeFederativa = "PR",
                Endereco = "Rua dos Pinheiros, 400, Jardim Botânico, Curitiba, PR - 14000-400",
                URLsImagens = new List<string> { "http://exemplo.com/comercial10.jpg", "http://exemplo.com/comercial11.jpg", "http://exemplo.com/comercial12.jpg" },
                Descricao = "Espaço comercial versátil no Jardim Botânico, ótimo para clínicas ou consultórios.",
                AreasComuns = new List<string> { "Estacionamento", "Recepção", "Sala de Espera", "Segurança 24h", "Elevador" },
                Banheiros = 3,
                Vagas = 8,
                TipoNegocio = "Clínica"
            };
            new Comercial
            {
                Id = null,
                Tipo = "Comercial",
                Area = 220.0,
                Preco = 1700000.00,
                Anos = 12,
                CEP = "15000-500", 
                Rua = "Avenida do Comércio",
                Numero = 500,
                Bairro = "Centro",
                Cidade = "Fortaleza",
                UnidadeFederativa = "CE",
                Endereco = "Avenida do Comércio, 500, Centro, Fortaleza, CE - 15000-500",
                URLsImagens = new List<string> { "http://exemplo.com/comercial13.jpg", "http://exemplo.com/comercial14.jpg", "http://exemplo.com/comercial15.jpg" },
                Descricao = "Espaço comercial amplo no Centro de Fortaleza, perfeito para grandes lojas ou supermercados.",
                AreasComuns = new List<string> { "Estacionamento", "Área de Carga e Descarga", "Sistema de Vigilância", "Segurança 24h", "Área de Escritório" },
                Banheiros = 5,
                Vagas = 20,
                TipoNegocio = "Supermercado"
            };

            new Lote
            {
                Id = null,
                Tipo = "Lote",
                Area = 415.0,
                Preco = 190000.00,
                Anos = 1,
                CEP = "34536-102",
                Rua = "Rua dos Tropeiros",
                Numero = 25,
                Bairro = "Vila Real",
                Cidade = "Sabará",
                UnidadeFederativa = "MG",
                Endereco = "Rua dos Tropeiros, 25, Vila Real, Sabará, MG - 34536-102",
                URLsImagens = new List<string> { "http://exemplo.com/comercial13.jpg", "http://exemplo.com/comercial14.jpg", "http://exemplo.com/comercial15.jpg" },
                Descricao = "Lote em excelente localização no Bairro Vila Real, com 415m², com topografia plana.\r\n\r\nAceita financiamento bancário!\r\n\r\nO bairro é totalmente planejado e fica próximo ao centro histórico de Sabará.\r\n\r\nAproveite a opção de financiamento de terreno e construção e realize seu sonho da casa própria!\r\n\r\nTipo do imóvel: Lote\r\nMetragem útil: 415m²\r\nTotal dormitórios: 0\r\nTotal suítes: 0\r\nLocalização: Villa Real | Sabará\r\nValor: R$190.000\r\n\r\nVilla Real é um bairro histórico e encantador na cidade de Sabará, Minas Gerais. Localizado na região central da cidade, Villa Real é conhecido por suas ruas arborizadas, casas antigas e belas igrejas.\r\n\r\nVilla Real foi fundada em 1810 por um grupo de imigrantes portugueses, que trouxeram consigo a cultura e a tradição da sua terra natal. Desde então, o bairro tem se desenvolvido e se transformado em um lugar de grande beleza e encanto.\r\n\r\nHoje, Villa Real é um dos bairros mais procurados da cidade. Os moradores desfrutam de uma vida tranquila e segura, com diversas opções de lazer e entretenimento. O bairro conta com parques, praças, museus, teatros, restaurantes, bares e muito mais.\r\n\r\nVilla Real é também um bairro de grande importância histórica. Suas ruas estão repletas de construções antigas, que contam a história da cidade e de seus habitantes.\r\n\r\nVenha conhecer Villa Real e se encantar com sua beleza e história!\r\n\r\nClique no botão ao lado e iremos entrar em contato para te ajudar na busca pelo imóvel ideal!\r\n\r\nA NEWCORE possui diversas equipes especializadas em várias regiões do Brasil, com corretores experientes e capacitados que te ajudarão a encontrar o imóvel dos seus sonhos\r\nAnúncio do corretor de imóveis Rosemary Leônidas Ferreira CRECI: 43921",
                AreasComuns = new List<string> { }
            };
            new Lote
            {
                Id = null,
                Tipo = "Lote",
                Area = 360.0,
                Preco = 90000.00,
                Anos = 1,
                CEP = "34525-260",
                Rua = "Travessa Santa Helena",
                Numero = 45,
                Bairro = "Corrego Da Ilha",
                Cidade = "Sabará",
                UnidadeFederativa = "MG",
                Endereco = "Travessa Santa Helena, 45, Corrego Da Ilha, Sabará, MG - 34525-260",
                URLsImagens = new List<string> { "http://exemplo.com/comercial13.jpg", "http://exemplo.com/comercial14.jpg", "http://exemplo.com/comercial15.jpg" },
                Descricao = "Lote a venda em Travessa Santa Helena - Córrego da Ilha - Sabará/MG\r\n\r\nLote em Sabará!\r\n\r\nVende-se lote de 360 metros no Bairro Córrego da Ilha - Sabará.\r\n\r\nExcelente lote de esquina, o que possibilita inclusive construção de casas geminadas.\r\n\r\nPossibilidade de financiamento de parte do valor.\r\n\r\nChame para maiores informações!\r\n\r\nTipo do imóvel: Lote\r\nMetragem útil: 360m²\r\nTotal dormitórios: 0\r\nTotal suítes: 0\r\nLocalização: Córrego da Ilha | Sabará\r\nValor: R$90.000\r\n\r\nO Bairro Córrego da Ilha, localizado na cidade de Sabará, é um lugar único. Com sua história rica e diversidade cultural, o bairro é um dos mais antigos da cidade.\r\n\r\nAqui, você pode desfrutar de uma variedade de serviços, como restaurantes, lojas, bares, parques e muito mais. O bairro também conta com algumas das melhores escolas da região, oferecendo educação de qualidade para as crianças.\r\n\r\nAlém disso, o Córrego da Ilha é conhecido por sua beleza natural. O rio que passa pelo bairro é um dos mais bonitos da região, e oferece aos moradores a oportunidade de desfrutar de um ambiente tranquilo e relaxante.\r\n\r\nA história do bairro remonta ao século XVIII, quando foi fundado por imigrantes portugueses. Desde então, o bairro tem se desenvolvido e se tornou um dos mais importantes da cidade.\r\n\r\nSe você está procurando por um lugar tranquilo e acolhedor para viver, o Bairro Córrego da Ilha é o lugar ideal. Venha conhecer e desfrutar de tudo o que ele tem a oferecer!\r\n\r\nClique no botão ao lado e iremos entrar em contato para te ajudar na busca pelo imóvel ideal!\r\n\r\nA NEWCORE possui diversas equipes especializadas em várias regiões do Brasil, com corretores experientes e capacitados que te ajudarão a encontrar o imóvel dos seus sonhos\r\nAnúncio do corretor de imóveis Rosemary Leônidas Ferreira CRECI: 43921",
                AreasComuns = new List<string> { }
            };
            new Lote
            {
                Id = null,
                Tipo = "Lote",
                Area = 250.0,
                Preco = 33000.00,
                Anos = 1,
                CEP = "34555-060",
                Rua = "Rua Miguel Cervantes",
                Numero = null,
                Bairro = "Rosário",
                Cidade = "Sabará",
                UnidadeFederativa = "MG",
                Endereco = "Rua Miguel Cervantes, S.N.º, Rosário, Sabará, MG - 34555-060",
                URLsImagens = new List<string> { "http://exemplo.com/comercial13.jpg", "http://exemplo.com/comercial14.jpg", "http://exemplo.com/comercial15.jpg" },
                Descricao = "OPORTUNIDADE LOTE DE 250 m2 À VENDA NO BAIRRO ROSÁRIO 1 EM SABARÁ MG COM REGISTRO/ESCRITURA EM MÃOS Terreno para comprar no bairro Rosário, localizado na cidade de Sabará - MG.Infraestruturas:- Para a família- Para investir- Área verde",
                AreasComuns = new List<string> { }
            };
            new Lote
            {
                Id = null,
                Tipo = "Lote",
                Area = 360.0,
                Preco = 97000.00,
                Anos = 1,
                CEP = "34525-300",
                Rua = "Rua Santa Tereza",
                Numero = 3,
                Bairro = "Morro Da Cruz",
                Cidade = "Sabará",
                UnidadeFederativa = "MG",
                Endereco = "Rua Santa Tereza, 3, Morro Da Cruz, Sabará, MG - 34525-300",
                URLsImagens = new List<string> { "http://exemplo.com/comercial13.jpg", "http://exemplo.com/comercial14.jpg", "http://exemplo.com/comercial15.jpg" },
                Descricao = "Lote a venda em Rua Santa Tereza - Morro da Cruz - Sabará/MG\r\n\r\nLote de 360m² à venda no bairro Morro da Cruz, em Sabará MG.\r\n\r\nVende-se lote no bairro Morro da Cruz!!\r\n\r\nÓtima oportunidade para quem quer construir sua casa tendo uma vista maravilhosa da cidade histórica de Sabará, MG.\r\n\r\nCirculação de ônibus, a poucos minutos do centro histórico.\r\n\r\nPossui escritura!\r\n\r\nTipo do imóvel: Lote\r\nMetragem útil: 360m²\r\nTotal dormitórios: 0\r\nTotal suítes: 0\r\nLocalização: Morro da Cruz | Sabará\r\nValor: R$97.000\r\n\r\nVenha conhecer o encantador bairro Morro da Cruz, em Sabará! Localizado na região metropolitana de Belo Horizonte, o bairro é conhecido por sua bela paisagem, com suas montanhas e rios, e também por sua história.\r\n\r\nO Morro da Cruz foi fundado em 1720, quando os portugueses chegaram à região e construíram um forte para proteger a cidade de invasores. Desde então, o bairro tem se desenvolvido e se tornado um lugar acolhedor para se viver.\r\n\r\nHoje, o bairro Morro da Cruz é um dos mais procurados da região. Oferece uma variedade de serviços e atrações, como restaurantes, lojas, parques, museus e muito mais. Além disso, o bairro possui uma grande diversidade de culturas, como a portuguesa, a brasileira e a africana.\r\n\r\nVenha conhecer o bairro Morro da Cruz e se encantar com sua beleza e sua história. Aqui, você encontrará tudo o que precisa para desfrutar de uma ótima experiência. Venha para o Morro da Cruz e descubra o que há de melhor em Sabará!\r\n\r\nClique no botão ao lado e iremos entrar em contato para te ajudar na busca pelo imóvel ideal!\r\n\r\nA NEWCORE possui diversas equipes especializadas em várias regiões do Brasil, com corretores experientes e capacitados que te ajudarão a encontrar o imóvel dos seus sonhos\r\nAnúncio do corretor de imóveis Rosemary Leônidas Ferreira CRECI: 43921",
                AreasComuns = new List<string> { }
            };
            new Lote
            {
                Id = null,
                Tipo = "Lote",
                Area = 200.0,
                Preco = 90000.00,
                Anos = 1,
                CEP = "34515-360",
                Rua = "Rua José Vítor Hamacek",
                Numero = 100,
                Bairro = "Esplanada",
                Cidade = "Sabará",
                UnidadeFederativa = "MG",
                Endereco = "Rua José Vítor Hamacek, 100, Esplanada, Sabará, MG - 34515-360",
                URLsImagens = new List<string> { "http://exemplo.com/comercial13.jpg", "http://exemplo.com/comercial14.jpg", "http://exemplo.com/comercial15.jpg" },
                Descricao = "Lote a venda em Rua José Vítor Hamacek - Esplanada - Sabará/MG\r\n\r\nLote no Bairro Esplanada!\r\n\r\nVende-se lote no Bairro Esplanada, com 200m em boa localização no Bairro .\r\n\r\nBairro tradicional de Sabará, com comércio próximo, ponto de ônibus e 10 minutos do centro!\r\n\r\nAgende uma visita!\r\n\r\nobs. Não aceita financiamento bancário.\r\n\r\nTipo do imóvel: Lote\r\nMetragem útil: 200m²\r\nTotal dormitórios: 0\r\nTotal suítes: 0\r\nLocalização: Esplanada | Sabará\r\nValor: R$90.000\r\n\r\nVenha para o Bairro Esplanada, em Sabará, e descubra o que há de melhor na cidade!\r\n\r\nO Bairro Esplanada é um bairro tranquilo, com muitas áreas verdes e parques, que oferecem aos moradores a oportunidade de desfrutar de momentos de lazer e relaxamento.\r\n\r\nAlém disso, o Bairro Esplanada também possui uma grande variedade de serviços, como escolas, lojas, restaurantes, bares e muito mais.\r\n\r\nA história do Bairro Esplanada remonta ao século XIX, quando foi fundado por imigrantes italianos. Desde então, o bairro tem se desenvolvido e se transformado em um dos melhores bairros de Sabará.\r\n\r\nVenha para o Bairro Esplanada e descubra o que há de melhor na cidade! Aqui você encontrará tranquilidade, lazer, serviços e muita história. Venha para o Bairro Esplanada e desfrute de tudo o que a cidade tem a oferecer!\r\n\r\nClique no botão ao lado e entraremos em contato o mais rápido possível!\r\n\r\nA NEWCORE possui diversas equipes especializadas em várias regiões do Brasil, com corretores experientes e capacitados que te ajudarão a encontrar o imóvel dos seus sonhos\r\nAnúncio do corretor de imóveis Rosemary Leônidas Ferreira CRECI: 43921",
                AreasComuns = new List<string> { }
            };

            // Rural

            // Terreno
        };
    }
}