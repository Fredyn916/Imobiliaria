using Entidades.Imoveis.Filho;
using Entidades.Imoveis.Pai;
using Entidades.Interfaces.Imoveis;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System.Data.Entity;

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

    public async Task InicializarImoveisPreDefinidos()
    {
        var quantidade = await _Imoveis.CountDocumentsAsync(Builders<Imovel>.Filter.Empty);

        if (quantidade == null || quantidade == 0)
        {
            List<Imovel> imoveisPreDefinidos = new List<Imovel>()
            {
                new Apartamento
                {
                    Id = null,
                    Tipo = "Apartamento",
                    Area = 45.0,    
                    Preco = 310990.00,
                    Anos = 5,
                    TipoServico = "Comprar",
                    CEP = "30580-040",
                    Rua = "Rua das Canoas",
                    Numero = 35,
                    Bairro = "Estrela do Oriente",
                    Cidade = "Belo Horizonte",
                    UnidadeFederativa = "MG",
                    Endereco = "Rua das Canoas, 35, Estrela do Oriente, Belo Horizonte, MG - 30580-040",
                    URLsImagens = new List<string> { "https://res.cloudinary.com/fredmarques/image/upload/v1733161291/Ap1Foto1_ldxnak.jpg", "https://res.cloudinary.com/fredmarques/image/upload/v1733161292/Ap1Foto2_oujfzb.webp", "https://res.cloudinary.com/fredmarques/image/upload/v1733161292/Ap1Foto3_kqck5g.webp", "https://res.cloudinary.com/fredmarques/image/upload/v1733161291/Ap1Foto4_ohvk47.webp", "https://res.cloudinary.com/fredmarques/image/upload/v1733161291/Ap1Foto5_eanudy.webp", "https://res.cloudinary.com/fredmarques/image/upload/v1733161291/Ap1Foto6_fgyfmr.webp" },
                    Titulo = "Residencial em Meio à Natureza",
                    Descricao = "Localizado a apenas 9 minutos do centro de Belo Horizonte, com fácil acesso pela Av. Tereza Cristina e Rua Úrsula Paulino. Oferece tranquilidade, segurança e conforto.\r\n\r\nCaracterísticas dos Apartamentos:\r\n\r\n2 quartos com opção de suíte\r\nTodos com varanda\r\nElevador\r\nLazer completo\r\nDiferenciais do Imóvel:\r\n\r\nBancadas da cozinha e dos banheiros em granito\r\nCerâmica na cozinha e banheiros\r\nDispositivos economizadores de água (redutor de vazão e sistema de descarga)\r\nOpção de suíte\r\nPiso em cerâmica na sala e laminado nos quartos\r\nPrevisão para ar-condicionado\r\nPrevisão para medição de água individualizada\r\nRevestimento total das áreas molhadas\r\nTanque em mármore sintético\r\nFinanciamento:\r\n\r\nFinanciamento direto com a construtora em 144 MESES\r\nObra garantida pela Caixa Econômica Federal\r\nEntrega prevista: Setembro de 2027",
                    AreasComuns = new List<string> { "Churrasqueira (parrilla)", "Escritório", "Varanda", "Espaço Gourmet", "Interfone" },
                    Quartos = 2,
                    Suites = 1,
                    Banheiros = 2,
                    Vagas = 1,
                    Andar = 7
                },
                new Apartamento
                {
                    Id = null,
                    Tipo = "Apartamento",
                    Area = 66.0,
                    Preco = 4750.00,
                    Anos = 3,
                    TipoServico = "Alugar",
                    CEP = "30190-094",
                    Rua = "Rua Martim de Carvalho",
                    Numero = 382,
                    Bairro = "Santo Agostinho",
                    Cidade = "Belo Horizonte",
                    UnidadeFederativa = "MG",
                    Endereco = "Rua Martim de Carvalho, 382, Santo Agostinho, Belo Horizonte, MG - 30190-094",
                    URLsImagens = new List<string> { "https://res.cloudinary.com/fredmarques/image/upload/v1733161417/Ap2Foto1_phlrwk.webp", "https://res.cloudinary.com/fredmarques/image/upload/v1733161416/Ap2Foto2_c3xgzy.jpg", "https://res.cloudinary.com/fredmarques/image/upload/v1733161416/Ap2Foto3_mtje6g.webp" },
                    Titulo = "Apartamento 2 suítes Santo Agostinho",
                    Descricao = "Excelente localização. Apartamento fino, decorado, projeto luminotécnico. Ar condicionado na sala e na suíte do casal. Fechadura biométrica. São duas suítes com armários. Sala para dois ambientes. Lavabo. Cozinha estilo americana com armários sob bancada e paredes; fogão cook top e coifa. Área de serviço independente com banho de serviço.\r\n\r\nPrincipais diferenciais: aquecimento solar; gás natural canalizado; moniotramento por câmeras; elevador inteligente com código de acesso; Venezanias retráteis em alumínio nas suítes; Tomadas para carros elétricos; Fitness center totalmente equipado; Medição de água individualizada; Wi-Fi nas áreas comuns; Guarita com porteiro virtual.\r\n\r\nOs valores estão sujeitos a alteração sem aviso prévio.",
                    AreasComuns = new List<string> { "Piscina", "Academia", "Salão de Festas", "Playground", "Quadra Poliesportiva" },
                    Quartos = 2,
                    Suites = 2,
                    Banheiros = 2,
                    Vagas = 2,
                    Andar = 4
                },
                new Apartamento
                {
                    Id = null,
                    Tipo = "Apartamento",
                    Area = 53.0,
                    Preco = 334900.00,
                    Anos = 3,
                    TipoServico = "Comprar",
                    CEP = "31730-590",
                    Rua = "Rua Vieira de Campos",
                    Numero = 44,
                    Bairro = "Planalto",
                    Cidade = "Belo Horizonte",
                    UnidadeFederativa = "MG",
                    Endereco = "Rua Vieira de Campos, 44, Planalto, Belo Horizonte, MG - 31730-590",
                    URLsImagens = new List<string> { "https://res.cloudinary.com/fredmarques/image/upload/v1733161516/Ap3Foto1_tj9f62.webp", "https://res.cloudinary.com/fredmarques/image/upload/v1733161515/Ap3Foto2_xxjhri.jpg", "https://res.cloudinary.com/fredmarques/image/upload/v1733161517/Ap3Foto3_cumde8.jpg", "https://res.cloudinary.com/fredmarques/image/upload/v1733161517/Ap3Foto4_bylawa.webp" },
                    Titulo = "Conheça o Edifício Montreal: Melhor Apartamento no Planalto, Belo Horizonte / MG",
                    Descricao = "Apê tipo - 02 quartos (01 suíte), 53,36m² a partir R$ 334.900,00;\r\n\r\nApê área privativa - 85,53m² Vendia;\r\n\r\nCobertura - 108,04m² Vendida;\r\n\r\nLink para navegar pelo prédio e Apê mobiliado em 3D virtual AQUI!\r\n\r\nLocalização Privilegiada: Situado no bairro Planalto, em BH, o Edifício Montreal oferece fácil acesso aos shoppings, 300 metros da estação Floramar, uma variedade de comércios locais e próximo a deslumbrante Lagoa da Pampulha.\r\nApartamentos aconchegantes com acabamento de qualidade: Com 02 quartos, incluindo uma suíte, piso em porcelanato e laminado em madeira nos quartos, sala com janela dupla (4 folhas), banheiros com nicho nos box, preparação para ar-condicionado, gás canalizado, água individual, vaga de garagem coberta. Nossos apartamentos foram projetados para proporcionar conforto e funcionalidade para você e sua família.\r\n\r\nFacilidades de Pagamento: Aproveite o prazo da obra e garanta seu novo lar com a entrega das chaves dentro de 02 anos. Além disso, oferecemos pagamento da entrada parcelado direto conosco em até 48x, com um plano montado especialmente para facilitar sua vida.\r\n\r\nConforto e Comodidade: Com uma torre de 9 andares no terreno, apenas 24 unidades e elevador, você desfrutará de privacidade e praticidade. Gás canalizado, preparação para ar-condicionado e água individual. No condomínio deixamos área gourmet (churrasco), jardim com paisagismo, espaço descanso e bicicleário, portaria eletrônica.\r\n\r\nVizinhança Formada e Comércios no Entorno: More 500 metros distância da Estação Floramar - Apartamentos com localização privilegiada para seu dia-a-dia, como Shopping Estação BH e Minas Shopping, Lagoa da Pampulha e Parque Lagoa do Nado, Centro Universitário UNA, Bancos, Farmácias e Conveniências, EMEI Planalto e muito mais.\r\n\r\nConheça as plantas: opção de mini office com sala estendida / mesa para 6 e varanda gourmet / cozinha americana. Oferecemos alteração de acabamento para deixar com seu ESTILO.\r\n\r\nAs unidades mais altas oferecem uma vista deslumbrante do horizonte da cidade.\r\n\r\nOBRA GARANTIDA PELA CAIXA, garantia de entrega e facilidade de pagamento! Certificações PBQP.H (Prgrama Brasileiro de Qualidade e Produtividade do Habitat) ISO9001",
                    AreasComuns = new List<string> { "Piso Porcelanato", "Piscina Aquecida", "Infraestrutura de ar condicionado", "Conceito Aberto" },
                    Quartos = 2,
                    Suites = 1,
                    Banheiros = 1,
                    Vagas = 3,
                    Andar = 8
                },
                new Apartamento
                {
                    Id = null,
                    Tipo = "Apartamento",
                    Area = 28.0,
                    Preco = 3490.00,
                    Anos = 10,
                    TipoServico = "Alugar",
                    CEP = "30720-380",
                    Rua = "Rua Vila Rica",
                    Numero = 614,
                    Bairro = "Padre Eustáquio",
                    Cidade = "Belo Horizonte",
                    UnidadeFederativa = "MG",
                    Endereco = "Rua Vila Rica, 614, Padre Eustáquio, Belo Horizonte, MG - 30720-380",
                    URLsImagens = new List<string> { "https://res.cloudinary.com/fredmarques/image/upload/v1733161665/Ap4Foto1_adskce.jpg", "https://res.cloudinary.com/fredmarques/image/upload/v1733161664/Ap4Foto2_cclzby.webp", "https://res.cloudinary.com/fredmarques/image/upload/v1733161666/Ap4Foto3_d0wppb.jpg", "https://res.cloudinary.com/fredmarques/image/upload/v1733161665/Ap4Foto4_vnudfx.webp" },
                    Titulo = "Descubra seu novo lar no coração do Padre Eustáquio, em Belo Horizonte!",
                    Descricao = "Este amplo apartamento, são 4 dormitórios e 2 banheiros, oferece espaço e conforto para você e sua família.\r\n\r\nA localização é um dos grandes destaques: a região é tranquila e conta com fácil acesso a escolas, supermercados e áreas de lazer. Além disso, o imóvel possui 2 vagas de garagem e uma suíte, garantindo praticidade e conforto no dia a dia.\r\n\r\nNão perca a oportunidade de viver bem! Entre em contato.",
                    AreasComuns = new List<string> { "Área de Serviço", "Armário(s) Embutido(s)", "Churrasqueira" },
                    Quartos = 4,
                    Suites = 1,
                    Banheiros = 2,
                    Vagas = 2,
                    Andar = 3
                },
                new Apartamento
                {
                    Id = null,
                    Tipo = "Apartamento",
                    Area = 160.0,
                    Preco = 1190000.00,
                    Anos = 5,
                    TipoServico = "Comprar",
                    CEP = "30180-163",
                    Rua = "Rua Felipe dos Santos",
                    Numero = 600,
                    Bairro = "Lourdes",
                    Cidade = "Belo Horizonte",
                    UnidadeFederativa = "MG",
                    Endereco = "Rua Felipe dos Santos, 600, Lourdes, Belo Horizonte, MG - 30180-163",
                    URLsImagens = new List<string> { "https://res.cloudinary.com/fredmarques/image/upload/v1733161783/Ap5Foto1_b5pqif.jpg", "https://res.cloudinary.com/fredmarques/image/upload/v1733161783/Ap5Foto2_ttzjqm.jpg", "https://res.cloudinary.com/fredmarques/image/upload/v1733161783/Ap5Foto3_s8q95d.jpg", "https://res.cloudinary.com/fredmarques/image/upload/v1733161785/Ap5Foto4_dnhh2s.webp", "https://res.cloudinary.com/fredmarques/image/upload/v1733161785/Ap5Foto5_vhkk7p.jpg" },
                    Titulo = "Excelente 04 Quartos transformado em 02 suítes com 160m² no coração do Lourdes",
                    Descricao = "Apto totalmente Modernizado!!\r\n\r\n04 Quartos transformado em 02 Suítes com ar condicionado e iluminação planejada\r\n\r\nSuíte Master com Closet\r\n\r\nBanho social\r\nRouparia\r\n\r\nSala para 03 ambientes com piso em porcelanato\r\nTeto em gesso com iluminação planejada\r\nLavabo\r\n\r\nCozinha estilo americana com armários planejados\r\nÁrea de serviço independente\r\nDCE\r\n\r\n01 vaga de garagem livre\r\n\r\nExcelente Localização!\r\n\r\nEntre av. Olegário Maciel e rua Santa Catarina\r\n\r\nAGENDE AGORA MESMO SUA VISITA!",
                    AreasComuns = new List<string> { "Ar Condicionado", "Salão de Festas", "Academia", "Estacionamento", "Espaço Pet" },
                    Quartos = 4,
                    Suites = 2,
                    Banheiros = 3,
                    Vagas = 1,
                    Andar = 7
                },

                new Casa
                {
                    Id = null,
                    Tipo = "Casa",
                    Area = 120.0,
                    Preco = 750000.00,
                    Anos = 8,
                    TipoServico = "Alugar",
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
                },
                new Casa
                {
                    Id = null,
                    Tipo = "Casa",
                    Area = 100.0,
                    Preco = 680000.00,
                    Anos = 6,
                    TipoServico = "Comprar",
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
                },
                new Casa
                {
                    Id = null,
                    Tipo = "Casa",
                    Area = 95.0,
                    Preco = 620000.00,
                    Anos = 10,
                    TipoServico = "Alugar",
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
                },
                new Casa
                {
                    Id = null,
                    Tipo = "Casa",
                    Area = 85.0,
                    Preco = 580000.00,
                    Anos = 4,
                    TipoServico = "Comprar",
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
                },
                new Casa
                {
                    Id = null,
                    Tipo = "Casa",
                    Area = 105.0,
                    Preco = 640000.00,
                    Anos = 7,
                    TipoServico = "Alugar",
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
                },

                new Comercial
                {
                    Id = null,
                    Tipo = "Comercial",
                    Area = 250.0,
                    Preco = 1500000.00,
                    Anos = 10,
                    TipoServico = "Comprar",
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
                },
                new Comercial
                {
                    Id = null,
                    Tipo = "Comercial",
                    Area = 150.0,
                    Preco = 900000.00,
                    Anos = 5,
                    TipoServico = "Alugar",
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
                },
                new Comercial
                {
                    Id = null,
                    Tipo = "Comercial",
                    Area = 300.0,
                    Preco = 2000000.00,
                    Anos = 15,
                    TipoServico = "Comprar",
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
                },
                new Comercial
                {
                    Id = null,
                    Tipo = "Comercial",
                    Area = 180.0,
                    Preco = 1200000.00,
                    Anos = 8,
                    TipoServico = "Alugar",
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
                },
                new Comercial
                {
                    Id = null,
                    Tipo = "Comercial",
                    Area = 220.0,
                    Preco = 1700000.00,
                    Anos = 12,
                    TipoServico = "Comprar",
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
                },

                new Lote
                {
                    Id = null,
                    Tipo = "Lote",
                    Area = 415.0,
                    Preco = 190000.00,
                    Anos = 1,
                    TipoServico = "Alugar",
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
                },
                new Lote
                {
                    Id = null,
                    Tipo = "Lote",
                    Area = 360.0,
                    Preco = 90000.00,
                    Anos = 1,
                    TipoServico = "Comprar",
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
                },
                new Lote
                {
                    Id = null,
                    Tipo = "Lote",
                    Area = 250.0,
                    Preco = 33000.00,
                    Anos = 1,
                    TipoServico = "Alugar",
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
                },
                new Lote
                {
                    Id = null,
                    Tipo = "Lote",
                    Area = 360.0,
                    Preco = 97000.00,
                    Anos = 1,
                    TipoServico = "Comprar",
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
                },
                new Lote
                {
                    Id = null,
                    Tipo = "Lote",
                    Area = 200.0,
                    Preco = 90000.00,
                    Anos = 1,
                    TipoServico = "Alugar",
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
                },

                new Rural
                {
                    Id = null,
                    Tipo = "Rural",
                    Area = 4800.0,
                    Preco = 19000.00,
                    Anos = 1,
                    TipoServico = "Comprar",
                    CEP = "13212-863",
                    Rua = "Rua Raymundo Lucente",
                    Numero = 810,
                    Bairro = "Vale dos Cebrantes",
                    Cidade = "Jundiaí",
                    UnidadeFederativa = "SP",
                    Endereco = "Rua Raymundo Lucente, 810, Vale dos Cebrantes, Jundiaí, SP - 13212-863",
                    URLsImagens = new List<string> { "http://exemplo.com/imagem28.jpg", "http://exemplo.com/imagem29.jpg", "http://exemplo.com/imagem30.jpg" },
                    Descricao = "Chacara No Interior de Sp Entre Jundiaí E Itu (50 Min de São Paulo) Com 6 Suítes\r\nReferência: 810 - Chacara no interior de Sp entre Jundiaí e Itu (50min de São Paulo) 100m da rodovia, com acesso em estrada asfaltada Guarita com segurança 24h em frente ao imóvel Área total do terreno: 4.800 m2 Área construída: 700 m2 Imóvel para hospedar 14 pessoas 6 suítes, sendo: 1 suíte master com banheira hidromassagem  2 suites internas 1 suíte externa (frente piscina) 2 demi-suites (banheiros independentes em frente)  Mobiliado  8 TVs Cozinha completa Despensa com geladeira e freezer Área interna e externa totalmente mobiliada Área de churrasco com forno a lenha Quiosque  Campo de futebol Pomar formado Piscina  Aquecimento solar  2 poços (sendo um semi artesiano) Água potável na casa toda 4 vagas cobertas e mais 6 descobertas  2 banheiros independentes para área da piscina  Área de depósito separada da casa principal Canil  Capela  Casa separada para caseiro",
                    AreasComuns = new List<string> { "Churrasqueira (parrilla)" },
                    Quartos = 6,
                    Suites = 6,
                    Banheiros = 9,
                    Vagas = 8
                },
                new Rural
                {
                    Id = null,
                    Tipo = "Rural",
                    Area = 16000.0,
                    Preco = 15000.00,
                    Anos = 2,
                    TipoServico = "Alugar",
                    CEP = "13098-500",
                    Rua = "Estrada Municipal",
                    Numero = null,
                    Bairro = "Fazenda Monte D'Este",
                    Cidade = "Campinas",
                    UnidadeFederativa = "SP",
                    Endereco = "Estrada Municipal, S.N.º, Fazenda Monte D'Este, Campinas, SP - 13098-500",
                    URLsImagens = new List<string> { "http://exemplo.com/imagem28.jpg", "http://exemplo.com/imagem29.jpg", "http://exemplo.com/imagem30.jpg" },
                    Descricao = "OPORTUNIDADE\r\n\r\nVenha desfrutar de momentos inesquecíveis em uma linda chácara para locação definitiva!! Com uma infraestrutura completa e espaços amplos, esta propriedade é perfeita para reunir familiares e amigos em um ambiente tranquilo e cercado pela natureza, podendo ainda ser utilizada para uma clinica de repouso ou algo de interesse comercial.\r\n\r\nA casa principal, conta com 5 quartos, sendo 3 suítes, todos decorados com bom gosto, você e seus convidados terão todo o conforto necessário para descansar e recarregar as energias. As suítes contam com banheiros privativos, proporcionando ainda mais comodidade sem contar a suite master com hidro.\r\n\r\nConta com uma casa de caseiro, com 2 quartos , cozinha, sala, banheiro, lavanderia e varanda\r\n\r\nAs 3 salas espaçosas e aconchegantes são ideais para momentos de descontração e integração. Neles, você poderá aproveitar para assistir a filmes, jogar jogos de tabuleiro ou simplesmente conversar e compartilhar momentos especiais com seus entes queridos.\r\n\r\nPara maior praticidade, a chácara possui 5 banheiros, evitando filas e proporcionando mais conforto para todos. Além disso, há 4 vagas de garagem coberta e podendo superar 30 vagas descobertas, garantindo segurança e comodidade para os veículos de todos os visitantes.\r\n\r\nCom uma área de 16.000 m2 e mais de 800 m² de construção, esse espaço é perfeito para quem busca tranquilidade e privacidade. Aqui, você poderá aproveitar ao máximo a piscina, o jardim e a área gourmet, que conta com churrasqueira , fogão a lenha, forno e um amplo espaço para confraternizações ao ar livre. Conta ainda com uma bela quadra poliesportiva.\r\n\r\nLocalizada em um local privilegiado, a chácara está próxima a áreas verdes, trilhas ecológicas e belas paisagens, proporcionando uma estadia única e revigorante. Além disso, está a poucos minutos do centro de Barão Geraldo e a Unicamp, onde você encontrará uma ampla variedade de comércios, restaurantes e atividades culturais.\r\n\r\nSe você procura um local para relaxar e aproveitar momentos especiais com seus entes queridos, essa chácara é a escolha perfeita. Garanta já a sua reserva e desfrute de uma experiência única em um ambiente acolhedor e repleto de conforto. Entre em contato conosco e agende uma visita para conhecer pessoalmente todos os encantos que essa propriedade tem a oferecer. - 04/07/2024",
                    AreasComuns = new List<string> { "Churrasqueira (parrilla)" },
                    Quartos = 5,
                    Suites = 3,
                    Banheiros = 5,
                    Vagas = 3
                },
                new Rural
                {
                    Id = null,
                    Tipo = "Rural",
                    Area = 313.00,
                    Preco = 4000.00,
                    Anos = 24,
                    TipoServico = "Comprar",
                    CEP = "13252-504",
                    Rua = "Rua Maria Amélia de Morais",
                    Numero = null,
                    Bairro = "Vivendas do Engenho D'Água",
                    Cidade = "Itatiba",
                    UnidadeFederativa = "SP",
                    Endereco = "Rua Maria Amélia de Morais, S.N.º, Vivendas do Engenho D'Água, Itatiba, SP - 13252-504",
                    URLsImagens = new List<string> { "http://exemplo.com/imagem28.jpg", "http://exemplo.com/imagem29.jpg", "http://exemplo.com/imagem30.jpg" },
                    Descricao = "Encante - Se Com Esta Maravilhosa Chácara No Engenho D'água Em Itatiba, Sp\r\nExplore o encanto desta incrível chácara situada no prestigiado bairro Vivendas do Engenho d'Água em Itatiba, SP. Com fácil acesso a serviços essenciais como UBS e mercados, esta propriedade oferece uma experiência única, combinando natureza, comodidade e lazer.\r\nCaracterísticas Principais:\r\nTerreno Amplo: 3.000 m2Lazer CompletoPavimento Térreo com Garagem para 4 Automóveis, Varanda Coberta, Sala de Jantar, Sala de Estar, Dormitório, Banheiro, Cozinha com Copa e LavanderiaPavimento Intermediário com Dormitório (podendo ser transformado em suíte) e BanheiroPavimento Superior com Dormitório e Varanda CobertaÁrea de Lazer com Piscina, Mini Campo de Futebol, Churrasqueira, Salão de Jogos com Cozinha, Vestiário e Quarto de HóspedesAmpla Área Verde com Jardim Paisagístico, Balanço, Área para Fogueira, Hortas Elevadas, Pomar com Mangueiras e AbacateiroReservatório de Água: 6.500 litros e Rede de Água da SabespObservações: Esta chácara proporciona uma harmoniosa combinação de conforto, entretenimento e contato direto com a natureza, ideal para quem busca qualidade de vida e momentos inesquecíveis em família.\r\nCaracterísticas Adicionais:\r\nVagas de garagemJardimPiscinaVarandaParcialmente MobiliadaSala de JogosLocal SossegadoPróximo à AutoestradaPróximo a Escolas e HospitaisResidencialTransporte Público PróximoEletricidadeRegistro de Água IndividualAgende sua visita e descubra o paraíso que esta chácara oferece! Entre em contato para mais informações.\r\nFlavio Lima\r\nCreci 247012",
                    AreasComuns = new List<string> { "Vigilância 24h" },
                    Quartos = 4,
                    Suites = 1,
                    Banheiros = 3,
                    Vagas = 1
                },
                new Rural
                {
                    Id = null,
                    Tipo = "Rural",
                    Area = 474.00,
                    Preco = 4700.00,
                    Anos = 14,
                    TipoServico = "Alugar",
                    CEP = "36406-380",
                    Rua = "Rua Geraldo Plaza",
                    Numero = null,
                    Bairro = "Amaro Ribeiro",
                    Cidade = "Conselheiro Lafaiete",
                    UnidadeFederativa = "MG",
                    Endereco = "Rua Geraldo Plaza, S.N.º, Amaro Ribeiro, Conselheiro Lafaiete, MG - 36406-380",
                    URLsImagens = new List<string> { "http://exemplo.com/imagem28.jpg", "http://exemplo.com/imagem29.jpg", "http://exemplo.com/imagem30.jpg" },
                    Descricao = "Rurais À Venda - Em Amaro Ribeiro\r\nChácara à venda e locação no bairro Amaro ribeiro, composta por 1.400 m², com poço artesiano, internet fibra óptica, piscina, área gourmet com churrasqueira, 02 residências com 02 banheiro,02 quartos,01 sala,01 cozinha.\r\nChácara Localizada à 1,5 KM do bairro Amaro Ribeiro.",
                    AreasComuns = new List<string> { "Vigilância 24h", "Churrasqueira (parrilla)", "Piscina" },
                    Quartos = 2,
                    Suites = 1,
                    Banheiros = 2,
                    Vagas = 10
                },
                new Rural
                {
                    Id = null,
                    Tipo = "Rural",
                    Area = 250.00,
                    Preco = 2700.00,
                    Anos = 8,
                    TipoServico = "Comprar",
                    CEP = "07662-870",
                    Rua = "Via de Acesso km 54 Rod Fernão Dias",
                    Numero = null,
                    Bairro = "Terra Preta",
                    Cidade = "Mairiporã",
                    UnidadeFederativa = "SP",
                    Endereco = "Via de Acesso km 54 Rod Fernão Dias, S.N.º, Terra Preta, Mairiporã, SP - 07662-870",
                    URLsImagens = new List<string> { "http://exemplo.com/imagem28.jpg", "http://exemplo.com/imagem29.jpg", "http://exemplo.com/imagem30.jpg" },
                    Descricao = "Linda Chácara Mairiporã Para Locação!\r\n\r\nLinda Chácara para Locação em Mairiporã com muito verde e ar puro em volta, vista para as montanhas, só chácaras, com 1.000 m² de terreno e 250 m² aproximadamente de área construída, piscina com hidromassagem, casa avarandada, campo de futebol, pomar, gruta e cascata, salão e área gourmet.\r\nValor de Locação R$ 3.000,00 mensais + IPTU! Baixou o valor hoje R$ 2.700,00!!",
                    AreasComuns = new List<string> { "Vigilância 24h", "Piscina" },
                    Quartos = 2,
                    Suites = 1,
                    Banheiros = 2,
                    Vagas = 10
                },

                new Terreno
                {
                    Id = null,
                    Tipo = "Terreno",
                    Area = 210000.00,
                    Preco = 37800000.00,
                    Anos = 2,
                    TipoServico = "Alugar",
                    CEP = "12916-400",
                    Rua = "Avenida Salvador Markowicz",
                    Numero = 33,
                    Bairro = "Lagos de Santa Helena",
                    Cidade = "Bragança Paulista",
                    UnidadeFederativa = "SP",
                    Endereco = "Avenida Salvador Markowicz, 33, Lagos de Santa Helena, Bragança Paulista, SP - 12916-400",
                    URLsImagens = new List<string> { "http://exemplo.com/imagem28.jpg", "http://exemplo.com/imagem29.jpg", "http://exemplo.com/imagem30.jpg" },
                    Descricao = "Terreno À Venda, m² por R$ - Lagos de Santa Helena - Bragança Paulista/sp\r\nO terreno de 210.000,00 m² às margens da Fernão Dias, localizado em área nobre de Bragança Paulista, realmente representa uma oportunidade excepcional para diversos tipos de empreendimentos de alto padrão, como condomínios residenciais, shopping centers, restaurantes, hotéis, entre outros. A localização privilegiada às margens da rodovia proporciona excelente visibilidade e acessibilidade, fatores essenciais para o sucesso de projetos comerciais e residenciais de grande porte.\r\n\r\nSe você está interessado em explorar essa oportunidade ou precisa de mais informações sobre o terreno, incluindo detalhes específicos sobre condições de venda, viabilidade de projetos e agendamento de visitas para ver pessoalmente o local, recomendo entrar em contato diretamente com a. Eles têm a expertise necessária para fornecer todo o suporte necessário e ajudá-lo a tomar decisões informadas nesse processo de aquisição ou investimento imobiliário.\r\n\r\nPara mais novidades, lançamentos e atualizações do mercado imobiliário, você pode seguir a nas redes sociais:\r\n\r\nInstagram: @123mudei.imoveis, @aurelioprz, @klebermartellibroker\r\nFacebook: 123mudei Imóveis\r\nEles compartilham informações importantes e oportunidades de investimento que podem ser do seu interesse.",
                    AreasComuns = new List<string> { }
                },
                new Terreno
                {
                    Id = null,
                    Tipo = "Terreno",
                    Area = 452.00,
                    Preco = 37800000.00,
                    Anos = 3,
                    TipoServico = "Comprar",
                    CEP = "12916-352",
                    Rua = "Alameda do Porto",
                    Numero = 79,
                    Bairro = "Condomínio Residencial Fazenda Santa Helena",
                    Cidade = "Bragança Paulista",
                    UnidadeFederativa = "SP",
                    Endereco = "Alameda do Porto, 79, Condomínio Residencial Fazenda Santa Helena, Bragança Paulista, SP - 12916-352",
                    URLsImagens = new List<string> { "http://exemplo.com/imagem28.jpg", "http://exemplo.com/imagem29.jpg", "http://exemplo.com/imagem30.jpg" },
                    Descricao = "Terreno À Venda No Condomínio Portal Horizonte Em Bragança Paulista - Sp.\r\nTerreno à venda no condomínio fechado Portal Bragança Horizonte em Bragança Paulista-SP.\r\n\r\nÓtima oportunidade de construir a casa dos sonhos nesse terreno com leve aclive em um dos condomínios mais desejados de Bragança.\r\n\r\nCondomínio com infraestrutura completa , próximo dos principais pontos da cidade como Universidade, Lago do Taboão e fácil acesso à Rod. Fernão Dias.\r\n\r\nAgende já sua visita e conheça esse belo terreno.",
                    AreasComuns = new List<string> { }
                },
                new Terreno
                {
                    Id = null,
                    Tipo = "Terreno",
                    Area = 500.00,
                    Preco = 45000000.00,
                    Anos = 5,
                    TipoServico = "Alugar",
                    CEP = "12345-678",
                    Rua = "Rua das Flores",
                    Numero = 50,
                    Bairro = "Jardim Primavera",
                    Cidade = "São Paulo",
                    UnidadeFederativa = "SP",
                    Endereco = "Rua das Flores, 50, Jardim Primavera, São Paulo, SP - 12345-678",
                    URLsImagens = new List<string> { "http://exemplo.com/imagem31.jpg", "http://exemplo.com/imagem32.jpg", "http://exemplo.com/imagem33.jpg" },
                    Descricao = "Terreno excelente em localização privilegiada com fácil acesso às principais vias da cidade.",
                    AreasComuns = new List<string> { "Parque", "Área de Lazer" }
                },
                new Terreno
                {
                    Id = null,
                    Tipo = "Terreno",
                    Area = 300.00,
                    Preco = 30000000.00,
                    Anos = 2,
                    TipoServico = "Comprar",
                    CEP = "87654-321",
                    Rua = "Avenida Central",
                    Numero = 200,
                    Bairro = "Centro",
                    Cidade = "Rio de Janeiro",
                    UnidadeFederativa = "RJ",
                    Endereco = "Avenida Central, 200, Centro, Rio de Janeiro, RJ - 87654-321",
                    URLsImagens = new List<string> { "http://exemplo.com/imagem34.jpg", "http://exemplo.com/imagem35.jpg", "http://exemplo.com/imagem36.jpg" },
                    Descricao = "Terreno no centro do Rio de Janeiro, perfeito para construção de edifício comercial.",
                    AreasComuns = new List<string> { "Estacionamento", "Praça" }
                },
                new Terreno
                {
                    Id = null,
                    Tipo = "Terreno",
                    Area = 750.00,
                    Preco = 60000000.00,
                    Anos = 10,
                    TipoServico = "Alugar",
                    CEP = "56789-012",
                    Rua = "Estrada do Campo",
                    Numero = 150,
                    Bairro = "Zona Rural",
                    Cidade = "Belo Horizonte",
                    UnidadeFederativa = "MG",
                    Endereco = "Estrada do Campo, 150, Zona Rural, Belo Horizonte, MG - 56789-012",
                    URLsImagens = new List<string> { "http://exemplo.com/imagem37.jpg", "http://exemplo.com/imagem38.jpg", "http://exemplo.com/imagem39.jpg" },
                    Descricao = "Terreno amplo na zona rural de Belo Horizonte, ideal para agricultura ou criação de animais.",
                    AreasComuns = new List<string> { "Lago", "Área Verde" }
                }
            };

            await _Imoveis.InsertManyAsync(imoveisPreDefinidos);
        }
    }
}