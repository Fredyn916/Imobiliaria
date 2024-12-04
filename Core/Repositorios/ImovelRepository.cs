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
                    Area = 428.0,
                    Preco = 3590000.00,
                    Anos = 3,
                    TipoServico = "Comprar",
                    CEP = "34018-092",
                    Rua = "Rua dos Flamboyants",
                    Numero = 103,
                    Bairro = "Alphaville - Lagoa dos Ingleses",
                    Cidade = "Nova Lima",
                    UnidadeFederativa = "MG",
                    Endereco = "Rua dos Flamboyants, 103, Alphaville - Lagoa dos Ingleses, Nova Lima, MG - 34018-092",
                    URLsImagens = new List<string> { "https://res.cloudinary.com/fredmarques/image/upload/v1733244849/Casa1Foto1_hdh7h0.webp", "https://res.cloudinary.com/fredmarques/image/upload/v1733244849/Casa1Foto2_cgjez4.webp", "https://res.cloudinary.com/fredmarques/image/upload/v1733244849/Casa1Foto3_yempbc.webp", "https://res.cloudinary.com/fredmarques/image/upload/v1733244848/Casa1Foto4_w1pasu.webp", "https://res.cloudinary.com/fredmarques/image/upload/v1733244849/Casa1Foto5_xpzizf.webp" },
                    Titulo = "Excelente casa à venda com 4 suítes e lazer completo em Alphaville Lagoa dos Ingleses, Nova Lima/MG.",
                    Descricao = "Casa aconchegante com 428m² de área construída em um terreno de 640m² com fundo para a mata de preservação do Alphaville.\r\n\r\nNo primeiro nível ficam as 4 suites com piso em madeira natural, marcenaria completa, closet, janelas com venezianas e banhos em mármore. A suíte master possui banho com duas cubas, dois box e banheira de hidromassagem.\r\n\r\nSala com 3 ambientes, pé direito duplo, lavabo e todo o piso em madeira natural. Além disso a sala conta com um lindo jardim de inverno, acesso para garagem no pavimento inferior e acesso para o escritório no mesanino. Excelente escritório com linda marcenaria e varanda com vista para a mata.\r\n\r\nCozinha integrada com a sala, armários, despensa e acabamento todo em granito. Área de serviço com DCE.\r\n\r\nLazer com espaço gourmet externo, lavabo e piscina de fibra com deck de madeira. Visual da mata com total privacidade e sossego.\r\n\r\nA casa está em uma localização privilegiada, no alto da rua com linda vista e somente um vizinho. Em um das laterais da casa possui uma área verde do condomínio proporcionando privacidade à casa.\r\n\r\nGaragem coberta para 4 carros e possui box de despejo.\r\n\r\nPor que escolher o Alphaville para morar?\r\n\r\nAlphaville oferece uma localização privilegiada, ideal para quem busca tranquilidade e segurança para a sua família. Localizado a apenas 20 minutos do BH Shopping, este bairro conta com uma ampla estrutura de lazer, saúde, segurança e transporte.\r\n\r\nO Shopping Navegantes, presente no local, oferece uma variedade de comodidades, incluindo diversos restaurantes, o Supermercado Super Nosso, a Drogaria Araújo, as Lojas Americanas, o Laboratório Hermes Pardini, a Kopenhagen, entre outras facilidades que tornam a sua vida mais prática. Além disso, o Minas Tênis Náutico Clube oferece opções completas de lazer e entretenimento.\r\n\r\nNa área educacional, Alphaville conta com as melhores escolas da região, como o Colégio Batista Mineiro, a Maple Bear Canadense e a Fundação Dom Cabral.\r\n\r\nE isso não é tudo: o bairro possui um eficiente sistema de transporte exclusivo para os moradores, além de linhas alternativas para os funcionários, garantindo conveniência e acessibilidade. Com portaria 24 horas e um moderno sistema de segurança com câmeras, você pode desfrutar de tranquilidade e proteção em Alphaville.",
                    AreasComuns = new List<string> { "Piscina", "Condomínio Fechado", "Churrasqueira", "Playground", "Escritório", "Jardim" },
                    Quartos = 4,
                    Suites = 4,
                    Banheiros = 6,
                    Vagas = 5
                },
                new Casa
                {
                    Id = null,
                    Tipo = "Casa",
                    Area = 160.0,
                    Preco = 1100000.00,
                    Anos = 5,
                    TipoServico = "Comprar",
                    CEP = "30575-300",
                    Rua = "Rua Orlando Moretzsohn",
                    Numero = 31,
                    Bairro = "Buritis",
                    Cidade = "Belo Horizonte",
                    UnidadeFederativa = "MG",
                    Endereco = "Rua Orlando Moretzsohn, 31, Buritis, Belo Horizonte, MG - 30575-300",
                    URLsImagens = new List<string> { "https://res.cloudinary.com/fredmarques/image/upload/v1733245373/Casa2Foto4_jxwmbm.jpg", "https://res.cloudinary.com/fredmarques/image/upload/v1733245372/Casa2Foto1_zc0nwn.jpg", "https://res.cloudinary.com/fredmarques/image/upload/v1733245372/Casa2Foto3_ak0amc.jpg", "https://res.cloudinary.com/fredmarques/image/upload/v1733245372/Casa2Foto2_blwbgh.jpg" },
                    Titulo = "Casa com 3 quartos à venda na Orlando Moretzsohn, 31, Buritis, Belo Horizonte por R$ 1.100.000",
                    Descricao = "1º pavimento:\r\nSala aconchegante, clara e arejada para dois ambientes, lavabo, copa, cozinha com bancada em granito e armários planejados. Copa e escada em alvenaria e madeira.\r\n\r\n2º pavimento\r\n3 quartos, com armários, ar-condicionado, sendo uma suíte com closet, banho social e suíte com bancada em granito e armários, rouparia.\r\n\r\n3º pavimento\r\nlavanderia, sala, despensa, quarto.\r\n\r\nárea externa, parte coberta com churrasqueira bancada e armário, área descoberta com ducha.\r\n\r\n2 vagas , cobertas em linha",
                    AreasComuns = new List<string> { "Semimobiliado", "Armário(s) Embutido(s)", "Sacada com Churrasqueira", "Closet" },
                    Quartos = 3,
                    Suites = 1,
                    Banheiros = 2,
                    Vagas = 2
                },
                new Casa
                {
                    Id = null,
                    Tipo = "Casa",
                    Area = 250.0,
                    Preco = 5980.00,
                    Anos = 6,
                    TipoServico = "Alugar",
                    CEP = "22735-190",
                    Rua = "Rua Luís Cruls",
                    Numero = 25,
                    Bairro = "Tanque",
                    Cidade = "Rio de Janeiro",
                    UnidadeFederativa = "RJ",
                    Endereco = "Rua Luís Cruls, 25, Tanque, Rio de Janeiro, RJ - 22735-190",
                    URLsImagens = new List<string> { "https://res.cloudinary.com/fredmarques/image/upload/v1733245880/Casa3Foto1_ss3cps.jpg", "https://res.cloudinary.com/fredmarques/image/upload/v1733245880/Casa3Foto4_b3usgj.jpg", "https://res.cloudinary.com/fredmarques/image/upload/v1733245879/Casa3Foto2_ji3d9f.jpg", "https://res.cloudinary.com/fredmarques/image/upload/v1733245879/Casa3Foto3_bfxse6.jpg" },
                    Titulo = "Casa 5 qts | Piscina | Geremario Dantas | Candido Benicio",
                    Descricao = "Localizada no pitoresco bairro do Tanque, no Rio de Janeiro, esta encantadora casa de dois andares oferece o equilíbrio perfeito entre conforto, conveniência e lazer. Ao entrar pela porta de acesso, você é recebido por um espaçoso e acolhedor hall de entrada que leva à elegante sala de estar, ideal para receber visitas ou desfrutar de momentos de relaxamento em família.\r\nNo térreo, um dos cinco quartos proporciona praticidade e acessibilidade, perfeito para aqueles que preferem evitar escadas ou para receber hóspedes. Uma cozinha totalmente equipada com armários planejados e uma area de jantar adjacente criam o cenário ideal para experiências gastronômicas memoráveis.\r\nAo subir a escada, você é levado ao segundo andar, onde os outros quatro quartos oferecem amplo espaço e conforto para toda a família. O quarto principal é um verdadeiro refúgio, com um espaçoso closet e um banheiro privativo, proporcionando privacidade e conforto incomparáveis.\r\nA área de lazer é o destaque desta residência, com uma piscina convidativa e uma churrasqueira coberta, perfeita para encontros sociais ao ar livre e festas inesquecíveis. O charme da casa é complementado pela sensação de segurança e privacidade, sendo uma casa de vila com portão de acesso, proporcionando tranquilidade aos moradores.\r\nO bairro do Tanque, situado na Zona Oeste do Rio de Janeiro, é conhecido por sua atmosfera tranquila e familiar, com ruas arborizadas e uma ampla gama de serviços e comércios nas proximidades. Desde supermercados e padarias até restaurantes e escolas, tudo o que você precisa está a uma curta distância, proporcionando conveniência e praticidade para o seu dia a dia. Com fácil acesso às principais vias da cidade, você pode desfrutar de tudo o que o Rio de Janeiro tem a a oferecer, enquanto desfruta do conforto e da tranquilidade de sua própria casa no charmoso bairro do Tanque.",
                    AreasComuns = new List<string> { "Piscina", "Escritório", "Quintal", "Sacada", "Churrasqueira" },
                    Quartos = 5,
                    Suites = 1,
                    Banheiros = 4,
                    Vagas = 3
                },
                new Casa
                {
                    Id = null,
                    Tipo = "Casa",
                    Area = 587.0,
                    Preco = 5500.00,
                    Anos = 3,
                    TipoServico = "Alugar",
                    CEP = "59066-310",
                    Rua = "Rua Doutor José Pedro Bezerra",
                    Numero = 199,
                    Bairro = "Pitimbu",
                    Cidade = "Natal",
                    UnidadeFederativa = "RN",
                    Endereco = "Rua Doutor José Pedro Bezerra, 199, Pitimbu, Natal, RN - 59066-310",
                    URLsImagens = new List<string> { "https://res.cloudinary.com/fredmarques/image/upload/v1733246413/Casa4Foto1_uuwur7.jpg", "https://res.cloudinary.com/fredmarques/image/upload/v1733246413/Casa4Foto2_lchach.jpg", "https://res.cloudinary.com/fredmarques/image/upload/v1733246412/Casa4Foto3_jqvnrv.jpg", "https://res.cloudinary.com/fredmarques/image/upload/v1733246412/Casa4Foto4_ztiago.jpg" },
                    Titulo = "Casa com 5 dormitórios para alugar, 587 m² por R$ 280,04/ano - Pitimbu - Natal/RN",
                    Descricao = "Alugue agora esta incrível casa com 587,38m² de área construída em um terreno de 1600m²!\r\n\r\nPerfeita para quem busca espaço, conforto e tranquilidade.\r\n\r\nO que essa casa te oferece:\r\n\r\nEspaço amplo: 5 suítes para você e sua família desfrutarem de privacidade e conforto.\r\nLazer completo: Piscina para se refrescar nos dias quentes, mini quadra para praticar esportes e churrasqueira para reunir os amigos e familiares.\r\nTerreno generoso: 1600m² de área verde para você curtir a natureza e ter momentos de lazer ao ar livre.\r\nAcabamento de boa qualidade : A casa possui um acabamento impecável, com materiais de alta qualidade.\r\nLocalização privilegiada: Situada em Sanvale, um bairro tranquilo e sossegado.\r\n\r\nIdeal para:\r\n\r\nEmpresas que queiram montar escritório ou precise de salas e espaço.\r\nFamílias grandes que buscam um lar espaçoso e confortável.\r\nQuem busca tranquilidade e contato com a natureza.\r\nAmadores de esportes e atividades ao ar livre.\r\nNão perca essa oportunidade!\r\n\r\nAgende uma visita e encante-se com cada detalhe desta casa.\r\n\r\nInformações adicionais:\r\n\r\nÁrea do terreno: 1600m²\r\nÁrea construída: 587,38m²\r\nQuartos: 5 suítes\r\nVagas de garagem: 8 vagas de garagem\r\nValor do aluguel: R$ Sob Consulta",
                    AreasComuns = new List<string> { "Alarme", "Adega", "Ar Condicionado", "Churrasqueira", "Hidromassagem", "Escritório", "Piscina", "Quintal", "Jardim de Inverno" },
                    Quartos = 5,
                    Suites = 5,
                    Banheiros = 7,
                    Vagas = 8
                },
                new Casa
                {
                    Id = null,
                    Tipo = "Casa",
                    Area = 94.0,
                    Preco = 389000.00,
                    Anos = 5,
                    TipoServico = "Comprar",
                    CEP = "60762-080",
                    Rua = "Rua Mirtil Meyer",
                    Numero = 889,
                    Bairro = "Mondubim",
                    Cidade = "Fortaleza",
                    UnidadeFederativa = "CE",
                    Endereco = "Rua Mirtil Meyer, 889, Mondubim, Fortaleza, CE - 60762-080",
                    URLsImagens = new List<string> { "https://res.cloudinary.com/fredmarques/image/upload/v1733247066/Casa5Foto1_wffnec.webp", "https://res.cloudinary.com/fredmarques/image/upload/v1733247065/Casa5Foto2_pk78ds.webp", "https://res.cloudinary.com/fredmarques/image/upload/v1733247067/Casa5Foto3_qdagpl.webp", "https://res.cloudinary.com/fredmarques/image/upload/v1733247067/Casa5Foto4_uu7m4l.webp", "https://res.cloudinary.com/fredmarques/image/upload/v1733247066/Casa5Foto5_gnrece.webp" },
                    Titulo = "Casa duplex na maraponga",
                    Descricao = "Excelente oportunidade de casa duplex, nova, na melhor localização da região á poucas quadras da Godofredo Maciel e Benjamim Brasil, próximo a farmácias, supermercados, academia e escolas.\r\n\r\nA casa fica localizada em rua segura, possui 125m2 de terreno total, área construída de 95 m2 com 03 suítes para trazer mais privacidade a família, wc social, quintal com espaço para fazer um área de convivência, garagem para 03 carros e um espaço para proporcionar uma área de lazer íntima, varanda e um acabamento de alto padrão.\r\n\r\nDocumentação 100% ok, pode ser financiado e aceitamos proposta!!\r\n\r\nEntre em contato e agende sua visita!!!",
                    AreasComuns = new List<string> { "Quintal", "Quarto(s) com Sacada", "Jardim" },
                    Quartos = 3,
                    Suites = 3,
                    Banheiros = 4,
                    Vagas = 3
                },

                new Comercial
                {
                    Id = null,
                    Tipo = "Comercial",
                    Area = 35.0,
                    Preco = 190000.00,
                    Anos = 7,
                    TipoServico = "Comprar",
                    CEP = "51021-190",
                    Rua = "Rua Visconde de Jequitinhonha",
                    Numero = 279,
                    Bairro = "Boa Viagem",
                    Cidade = "Recife",
                    UnidadeFederativa = "PE",
                    Endereco = "Rua Visconde de Jequitinhonha, 279, Boa Viagem, Recife, PE - 51021-190",
                    URLsImagens = new List<string> { "https://res.cloudinary.com/fredmarques/image/upload/v1733248265/Comercial1Foto1_so22ve.jpg", "https://res.cloudinary.com/fredmarques/image/upload/v1733248265/Comercial1Foto2_xnbarz.jpg", "https://res.cloudinary.com/fredmarques/image/upload/v1733248266/Comercial1Foto3_sz7ydh.jpg", "https://res.cloudinary.com/fredmarques/image/upload/v1733248266/Comercial1Foto4_palp8t.jpg" },
                    Titulo = "Sala à venda, 35 m² por R$ 190.000,00 - Boa Viagem - Recife/PE",
                    Descricao = "Sala comercial à venda em Boa Viagem no Edf. Tancredo Neves, com uma excelente localização na Av. Visconde de Jequitinhonha de esquina com a Rua Ribeiro de Brito, próximo a Padaria Rio Tejo e a poucos metros do Shopping Center Recife. A sala possui 35 m² e um (01) wc social, sendo assim, uma excelente oportunidade de investimento ou ter o seu próprio negócio. Ligue e agende uma visita. Moradasol Imobiliária Referência: IMW 1559",
                    AreasComuns = new List<string> { "Estacionamento", "Elevador(es)" },
                    Banheiros = 1,
                    Vagas = 10,
                    TipoNegocio = "Sala Comercial"
                },
                new Comercial
                {
                    Id = null,
                    Tipo = "Comercial",
                    Area = 548.0,
                    Preco = 10000.00,
                    Anos = 4,
                    TipoServico = "Alugar",
                    CEP = "20540-342",
                    Rua = "Rua Barão do Bom Retiro",
                    Numero = 2748,
                    Bairro = "Grajaú",
                    Cidade = "Rio de Janeiro",
                    UnidadeFederativa = "RJ",
                    Endereco = "Rua Barão do Bom Retiro, 2748, Grajaú, Rio de Janeiro, RJ - 20540-342",
                    URLsImagens = new List<string> { "https://res.cloudinary.com/fredmarques/image/upload/v1733342093/Comercial2Foto1_lq3ps0.jpg", "https://res.cloudinary.com/fredmarques/image/upload/v1733342090/Comercial2Foto2_egwmcq.jpg", "https://res.cloudinary.com/fredmarques/image/upload/v1733342095/Comercial2Foto3_lpqctd.jpg", "https://res.cloudinary.com/fredmarques/image/upload/v1733342090/Comercial2Foto4_tof1fd.jpg" },
                    Titulo = "Loja para locação em Andaraí - RJ",
                    Descricao = "Este imóvel único apresenta uma loja de frente, anteriormente uma padaria, que foi transformada em um espaço versátil com escritórios e áreas de armazenamento distribuídos em 3 andares, totalizando uma área ampla de 571m².\r\nUma visita é imprescindível para explorar plenamente o potencial deste local. Sua localização estratégica, praticamente ao lado do Shopping Boulevard, oferece conveniência e visibilidade ideais para o seu empreendimento.\r\n\r\nNão deixe escapar essa oportunidade única de investimento! Agende agora mesmo a sua visita e descubra de perto todas as vantagens que este espaço exclusivo pode proporcionar para o seu negócio. Estamos aguardando o seu contato! REO990965.",
                    AreasComuns = new List<string> { "Salão", "Banheiro(s)" },
                    Banheiros = 5,
                    Vagas = 2,
                    TipoNegocio = "Loja"
                },
                new Comercial
                {
                    Id = null,
                    Tipo = "Comercial",
                    Area = 66.0,
                    Preco = 980000.00,
                    Anos = 11,
                    TipoServico = "Comprar",
                    CEP = "88330-795",
                    Rua = "Rua 1301",
                    Numero = 400,
                    Bairro = "Centro",
                    Cidade = "Balneário Camboriú",
                    UnidadeFederativa = "SC",
                    Endereco = "Rua 1301, 400, Centro, Balneário Camboriú, SC - 88330-795",
                    URLsImagens = new List<string> { "https://res.cloudinary.com/fredmarques/image/upload/v1733342408/Comercial3Foto1_ks3k9f.jpg", "https://res.cloudinary.com/fredmarques/image/upload/v1733342406/Comercial3Foto2_nxi8br.jpg", "https://res.cloudinary.com/fredmarques/image/upload/v1733342404/Comercial3Foto3_zxnczh.jpg" },
                    Titulo = "Sala à venda, 66 m² por R$ 980.000,00 - Centro - Balneário Camboriú/SC",
                    Descricao = "Sala comercial de alto padrão, segurança e praticidade para que a suas únicas preocupações sejam os negócios e seus clientes.\r\nConta com amplo espaço para reuniões, espaço confortável para uma reunião mais informal com um lindo Lounge Café, uma academia que gera qualidade de vida e conforto pessoal aos colaboradores e um lindo auditório com capacidade de 60 pessoas com equipamentos de áudio e som.\r\n\r\nSALA\r\n\r\n- 66,67m² DE ÁREA PRIVATIVA\r\n- 2 VAGAS DE GARAGEM E MAIS UMA VAGA ROTATIVA PARA SEUS CLIENTES\r\n- 2 BANHEIRO\r\n- COPA\r\n- PISO ELEVADO (PLANTA LIVRE)\r\n- TETO REBAIXADO EM GESSO\r\n- ESPAÇO EXTERNO PARA AR-CONDICIONADO SPLIT, COMPRESSOR DE AR E OUTROS EQUIPAMENTOS\r\n- ACABAMENTO EXTERNO EM PELE DE VIDRO, ALUMÍNIO, PINTURA\r\n- ACABAMENTO INETRNO EM PORCELANATO OU LAMINADO DE MADEIRA\r\n\r\n- AMPLO AUDITÓRIO\r\n- LOUNGE CAFÉ\r\n- ACADEMIA\r\n- PORTARIA 24H\r\n\r\nConfira as condições de pagamento\r\n*Valores, condições e disponibilidade dos imóveis anunciados neste site estão sujeitos a alterações e confirmações.\r\n\r\nVenha conferir esta oportunidade exclusiva que a Mercedes Imóveis selecionou para você!",
                    AreasComuns = new List<string> { "Piso Elevado", "Ar Condicionado", "Teto Rebaixado em Gesso" },
                    Banheiros = 2,
                    Vagas = 1,
                    TipoNegocio = "Escritório"
                },
                new Comercial
                {
                    Id = null,
                    Tipo = "Comercial",
                    Area = 590.0,
                    Preco = 24900.00,
                    Anos = 6,
                    TipoServico = "Alugar",
                    CEP = "80240-040",
                    Rua = "Avenida Presidente Getúlio Vargas",
                    Numero = 3358,
                    Bairro = "Água Verde",
                    Cidade = "Curitiba",
                    UnidadeFederativa = "PR",
                    Endereco = "Avenida Presidente Getúlio Vargas, 3358, Água Verde, Curitiba, PR - 80240-040",
                    URLsImagens = new List<string> { "https://res.cloudinary.com/fredmarques/image/upload/v1733342701/Comercial4Foto1_kb1xiq.jpg", "https://res.cloudinary.com/fredmarques/image/upload/v1733342699/Comercial4Foto2_xbry8q.jpg", "https://res.cloudinary.com/fredmarques/image/upload/v1733342697/Comercial4Foto3_oze0pg.jpg", "https://res.cloudinary.com/fredmarques/image/upload/v1733342703/Comercial4Foto4_yxwlws.jpg" },
                    Titulo = "Casa Comercial em Água Verde - Curitiba, PR",
                    Descricao = "Excelente casa comercial térrea, com 590m² na Avenida Pres. Getúlio Vargas. Salas amplas e integradas, 05 banheiros, copa/cozinha e salão de festas com churrasqueira. São 350m² no espaço principal e mais 240m² na edícula. Terreno com frente de 24m e área total de 1080m². Rua movimentada proporcionando muita exposição para sua marca. Agende sua visita com um de nossos corretores!",
                    AreasComuns = new List<string> { "Estacionamento", "Recepção", "Salão de Festas", "Churrasqueira", "Banheiro(s)" },
                    Banheiros = 5,
                    Vagas = 16,
                    TipoNegocio = "Casa Comercial"
                },
                new Comercial
                {
                    Id = null,
                    Tipo = "Comercial",
                    Area = 62.0,
                    Preco = 475000.00,
                    Anos = 8,
                    TipoServico = "Comprar",
                    CEP = "70655-775",
                    Rua = "SHCES Quadra 707 Bloco E",
                    Numero = 2,
                    Bairro = "Cruzeiro Novo",
                    Cidade = "Brasilia",
                    UnidadeFederativa = "DF",
                    Endereco = "SHCES Quadra 707 Bloco E, 2, Cruzeiro Novo, Brasilia, DF - 70655-775",
                    URLsImagens = new List<string> { "https://res.cloudinary.com/fredmarques/image/upload/v1733343457/Comercial5Foto1_hpclto.jpg", "https://res.cloudinary.com/fredmarques/image/upload/v1733343455/Comercial5Foto2_gugvdj.jpg", "https://res.cloudinary.com/fredmarques/image/upload/v1733343462/Comercial5Foto3_h45wkp.jpg", "https://res.cloudinary.com/fredmarques/image/upload/v1733343459/Comercial5Foto4_dlxfyp.jpg" },
                    Titulo = "Srtvs - Duas Salas Comerciais Unificadas - Desocupadas - 62m² - Reformadas",
                    Descricao = "Sala ampla, excelente oportunidade para o seu escritório;\r\n\r\nDuas Salas comerciais unificadas com 62 m², toda planejada, com armários, divisórias, ar condicionado; praça de alimentação, segurança 24 horas, estacionamento rotativo e espaço para eventos.\r\n\r\nPronta para sua pequena e média empresa, com acesso diário de pessoas que procuram auxílio para suprir seus negócios pessoais e profissionais.\r\nUm empreendimento de alto padrão, localizado no CENTRO MULTIEMPRESARIAL, ao lado Pátio Shopping brasil, Venâncio 2000, Parque da Cidade.",
                    AreasComuns = new List<string> { "Ar Condicionado", "Estacionamento Rotativo", "Sistema de Vigilância", "Segurança 24h" },
                    Banheiros = 2,
                    Vagas = 0,
                    TipoNegocio = "Escritório"
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
                    URLsImagens = new List<string> { "https://res.cloudinary.com/fredmarques/image/upload/v1733163170/Lote2Foto1_rwwuvf.webp", "https://res.cloudinary.com/fredmarques/image/upload/v1733163169/Lote2Foto2_byhzl9.webp", "https://res.cloudinary.com/fredmarques/image/upload/v1733163169/Lote2Foto3_xpbujm.webp", "https://res.cloudinary.com/fredmarques/image/upload/v1733163171/Lote2Foto4_yfu12t.webp" },
                    Titulo = "Lote em excelente localização no Bairro Vila Real, com 415m², com topografia plana.",
                    Descricao = "Aceita financiamento bancário!\r\n\r\nO bairro é totalmente planejado e fica próximo ao centro histórico de Sabará.\r\n\r\nAproveite a opção de financiamento de terreno e construção e realize seu sonho da casa própria!\r\n\r\nTipo do imóvel: Lote\r\nMetragem útil: 415m²\r\nTotal dormitórios: 0\r\nTotal suítes: 0\r\nLocalização: Villa Real | Sabará\r\nValor: R$190.000\r\n\r\nEu me especializei nessa região e tipo de imóvel, e com isso consigo te ajudar a tomar a melhor decisão e fazer um bom negócio.\r\n\r\nFico bem próximo ao imóvel. Entre em contato e marcamos rapidamente a visita.\r\nVocê pode clicar no botão ao lado ou me ligar\r\n\r\nVilla Real é um bairro histórico e encantador na cidade de Sabará, Minas Gerais. Localizado na região central da cidade, Villa Real é conhecido por suas ruas arborizadas, casas antigas e belas igrejas.\r\n\r\nVilla Real foi fundada em 1810 por um grupo de imigrantes portugueses, que trouxeram consigo a cultura e a tradição da sua terra natal. Desde então, o bairro tem se desenvolvido e se transformado em um lugar de grande beleza e encanto.\r\n\r\nHoje, Villa Real é um dos bairros mais procurados da cidade. Os moradores desfrutam de uma vida tranquila e segura, com diversas opções de lazer e entretenimento. O bairro conta com parques, praças, museus, teatros, restaurantes, bares e muito mais.\r\n\r\nVilla Real é também um bairro de grande importância histórica. Suas ruas estão repletas de construções antigas, que contam a história da cidade e de seus habitantes.\r\n\r\nVenha conhecer Villa Real e se encantar com sua beleza e história!\r\n\r\nAinda não encontrou o imóvel dos seus sonhos? Clique no botão ao lado que em breve entraremos em contato para te ajudar nessa busca!\r\n\r\nA NEWCORE possui diversas equipes especializadas em várias regiões do Brasil, com corretores experientes e capacitados que te ajudarão a encontrar o imóvel dos seus sonhos\r\nAnúncio do corretor de imóveis Rosemary Leônidas Ferreira CRECI: 43921",
                    AreasComuns = new List<string> { }
                },
                new Lote
                {
                    Id = null,
                    Tipo = "Lote",
                    Area = 360.0,
                    Preco = 89850.00,
                    Anos = 1,
                    TipoServico = "Comprar",
                    CEP = "34525-260",
                    Rua = "Travessa Santa Helena",
                    Numero = 45,
                    Bairro = "Corrego Da Ilha",
                    Cidade = "Sabará",
                    UnidadeFederativa = "MG",
                    Endereco = "Travessa Santa Helena, 45, Corrego Da Ilha, Sabará, MG - 34525-260",
                    URLsImagens = new List<string> { "https://res.cloudinary.com/fredmarques/image/upload/v1733162829/Lote1Foto1_wptv2p.webp", "https://res.cloudinary.com/fredmarques/image/upload/v1733162828/Lote1Foto2_my3i1k.webp", "https://res.cloudinary.com/fredmarques/image/upload/v1733162830/Lote1Foto3_cjx4dd.webp", "https://res.cloudinary.com/fredmarques/image/upload/v1733162829/Lote1Foto4_sadto7.webp" },
                    Titulo = "Lote em Sabará!",
                    Descricao = "Vende-se lote de 360 metros no Bairro Córrego da Ilha - Sabará.\r\n\r\nExcelente lote de esquina, o que possibilita inclusive construção de casas geminadas.\r\n\r\nPossibilidade de financiamento de parte do valor.\r\n\r\nChame para maiores informações!\r\n\r\nTipo do imóvel: Lote\r\nMetragem útil: 360m²\r\nTotal dormitórios: 0\r\nTotal suítes: 0\r\nLocalização: Córrego da Ilha | Sabará\r\nValor: R$90.000\r\n\r\nEu me especializei nessa região e tipo de imóvel, e com isso consigo te ajudar a tomar a melhor decisão e fazer um bom negócio.\r\n\r\nFico bem próximo ao imóvel. Entre em contato e marcamos rapidamente a visita.\r\nVocê pode clicar no botão ao lado ou me ligar\r\n\r\nO Bairro Córrego da Ilha, localizado na cidade de Sabará, é um lugar único. Com sua história rica e diversidade cultural, o bairro é um dos mais antigos da cidade.\r\n\r\nAqui, você pode desfrutar de uma variedade de serviços, como restaurantes, lojas, bares, parques e muito mais. O bairro também conta com algumas das melhores escolas da região, oferecendo educação de qualidade para as crianças.\r\n\r\nAlém disso, o Córrego da Ilha é conhecido por sua beleza natural. O rio que passa pelo bairro é um dos mais bonitos da região, e oferece aos moradores a oportunidade de desfrutar de um ambiente tranquilo e relaxante.\r\n\r\nA história do bairro remonta ao século XVIII, quando foi fundado por imigrantes portugueses. Desde então, o bairro tem se desenvolvido e se tornou um dos mais importantes da cidade.\r\n\r\nSe você está procurando por um lugar tranquilo e acolhedor para viver, o Bairro Córrego da Ilha é o lugar ideal. Venha conhecer e desfrutar de tudo o que ele tem a oferecer!\r\n\r\nAinda não encontrou o imóvel dos seus sonhos? Clique no botão ao lado que em breve entraremos em contato para te ajudar nessa busca!\r\n\r\nA NEWCORE possui diversas equipes especializadas em várias regiões do Brasil, com corretores experientes e capacitados que te ajudarão a encontrar o imóvel dos seus sonhos\r\nAnúncio do corretor de imóveis Rosemary Leônidas Ferreira CRECI: 43921",
                    AreasComuns = new List<string> { }
                },
                new Lote
                {
                    Id = null,
                    Tipo = "Lote",
                    Area = 250.0,
                    Preco = 33000.00,
                    Anos = 1,
                    TipoServico = "Comprar",
                    CEP = "34555-060",
                    Rua = "Rua Miguel Cervantes",
                    Numero = null,
                    Bairro = "Rosário",
                    Cidade = "Sabará",
                    UnidadeFederativa = "MG",
                    Endereco = "Rua Miguel Cervantes, S.N.º, Rosário, Sabará, MG - 34555-060",
                    URLsImagens = new List<string> { "https://res.cloudinary.com/fredmarques/image/upload/v1733163651/Lote3Foto1_c5vxhy.webp", "https://res.cloudinary.com/fredmarques/image/upload/v1733163713/Lote3Foto4_awxjxs.webp", "https://res.cloudinary.com/fredmarques/image/upload/v1733163652/Lote3Foto2_qoydku.webp", "https://res.cloudinary.com/fredmarques/image/upload/v1733163652/Lote3Foto3_hbvfln.webp" },
                    Titulo = "Lote na rua principal do bairro sendo para residencial ou comercial proximo de comercio variado ultimo lote vago da rua.",
                    Descricao = "Oportunidade para quem quer morar na região.\r\n\r\nBenefícios:\r\n\r\n- Ótima localização, próximo ao comércio variado facil acesso ao transporte coletivo Documentação esta 100% OK.\r\n-\r\nOs valores de venda / aluguel e dos encargos (IPTU/condomínio etc.) exibidos poderão sofrer mudanças e aumentos sem prévio aviso.\r\n\r\nPor esse motivo os valores deverão ser confirmados no nosso setor comercial e os encargos no prédio/condomínio e IPTU na Prefeitura.",
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
                    URLsImagens = new List<string> { "https://res.cloudinary.com/fredmarques/image/upload/v1733163932/Lote4Foto1_qw0sb2.webp", "https://res.cloudinary.com/fredmarques/image/upload/v1733163931/Lote4Foto2_whgr17.webp", "https://res.cloudinary.com/fredmarques/image/upload/v1733163930/Lote4Foto3_vlalct.webp", "https://res.cloudinary.com/fredmarques/image/upload/v1733163933/Lote4Foto4_zib83a.webp" },
                    Titulo = "Lote de 360m² à venda no bairro Morro da Cruz, em Sabará MG.",
                    Descricao = "Vende-se lote no bairro Morro da Cruz!!\r\n\r\nÓtima oportunidade para quem quer construir sua casa tendo uma vista maravilhosa da cidade histórica de Sabará, MG.\r\n\r\nCirculação de ônibus, a poucos minutos do centro histórico.\r\n\r\nPossui escritura!\r\n\r\nTipo do imóvel: Lote\r\nMetragem útil: 360m²\r\nTotal dormitórios: 0\r\nTotal suítes: 0\r\nLocalização: Morro da Cruz | Sabará\r\nValor: R$97.000\r\n\r\nEu me especializei nessa região e tipo de imóvel, e com isso consigo te ajudar a tomar a melhor decisão e fazer um bom negócio.\r\n\r\nFico bem próximo ao imóvel. Entre em contato e marcamos rapidamente a visita.\r\nVocê pode clicar no botão ao lado ou me ligar\r\n\r\nVenha conhecer o encantador bairro Morro da Cruz, em Sabará! Localizado na região metropolitana de Belo Horizonte, o bairro é conhecido por sua bela paisagem, com suas montanhas e rios, e também por sua história.\r\n\r\nO Morro da Cruz foi fundado em 1720, quando os portugueses chegaram à região e construíram um forte para proteger a cidade de invasores. Desde então, o bairro tem se desenvolvido e se tornado um lugar acolhedor para se viver.\r\n\r\nHoje, o bairro Morro da Cruz é um dos mais procurados da região. Oferece uma variedade de serviços e atrações, como restaurantes, lojas, parques, museus e muito mais. Além disso, o bairro possui uma grande diversidade de culturas, como a portuguesa, a brasileira e a africana.\r\n\r\nVenha conhecer o bairro Morro da Cruz e se encantar com sua beleza e sua história. Aqui, você encontrará tudo o que precisa para desfrutar de uma ótima experiência. Venha para o Morro da Cruz e descubra o que há de melhor em Sabará!\r\n\r\nAinda não encontrou o imóvel dos seus sonhos? Clique no botão ao lado que em breve entraremos em contato para te ajudar nessa busca!\r\n\r\nA NEWCORE possui diversas equipes especializadas em várias regiões do Brasil, com corretores experientes e capacitados que te ajudarão a encontrar o imóvel dos seus sonhos\r\nAnúncio do corretor de imóveis Rosemary Leônidas Ferreira CRECI: 43921",
                    AreasComuns = new List<string> { }
                },
                new Lote
                {
                    Id = null,
                    Tipo = "Lote",
                    Area = 200.0,
                    Preco = 89120.00,
                    Anos = 1,
                    TipoServico = "Comprar",
                    CEP = "34515-360",
                    Rua = "Rua José Vítor Hamacek",
                    Numero = 100,
                    Bairro = "Esplanada",
                    Cidade = "Sabará",
                    UnidadeFederativa = "MG",
                    Endereco = "Rua José Vítor Hamacek, 100, Esplanada, Sabará, MG - 34515-360",
                    URLsImagens = new List<string> { "https://res.cloudinary.com/fredmarques/image/upload/v1733164266/Lote5Foto1_rmsk5d.webp", "https://res.cloudinary.com/fredmarques/image/upload/v1733164265/Lote5Foto2_r9hqd1.webp", "https://res.cloudinary.com/fredmarques/image/upload/v1733164264/Lote5Foto3_s3wrby.webp", "https://res.cloudinary.com/fredmarques/image/upload/v1733164268/Lote5Foto4_erz30g.webp" },
                    Titulo = "Lote no Bairro Esplanada!",
                    Descricao = "Vende-se lote no Bairro Esplanada, com 200m em boa localização no Bairro .\r\n\r\nBairro tradicional de Sabará, com comércio próximo, ponto de ônibus e 10 minutos do centro!\r\n\r\nAgende uma visita!\r\n\r\nobs. Não aceita financiamento bancário.\r\n\r\nTipo do imóvel: Lote\r\nMetragem útil: 200m²\r\nTotal dormitórios: 0\r\nTotal suítes: 0\r\nLocalização: Esplanada | Sabará\r\nValor: R$90.000\r\n\r\nVenha para o Bairro Esplanada, em Sabará, e descubra o que há de melhor na cidade!\r\n\r\nO Bairro Esplanada é um bairro tranquilo, com muitas áreas verdes e parques, que oferecem aos moradores a oportunidade de desfrutar de momentos de lazer e relaxamento.\r\n\r\nAlém disso, o Bairro Esplanada também possui uma grande variedade de serviços, como escolas, lojas, restaurantes, bares e muito mais.\r\n\r\nA história do Bairro Esplanada remonta ao século XIX, quando foi fundado por imigrantes italianos. Desde então, o bairro tem se desenvolvido e se transformado em um dos melhores bairros de Sabará.\r\n\r\nVenha para o Bairro Esplanada e descubra o que há de melhor na cidade! Aqui você encontrará tranquilidade, lazer, serviços e muita história. Venha para o Bairro Esplanada e desfrute de tudo o que a cidade tem a oferecer!\r\n\r\nClique no botão ao lado e iremos entrar em contato para te ajudar na busca pelo imóvel ideal!\r\n\r\nA NEWCORE possui diversas equipes especializadas em várias regiões do Brasil, com corretores experientes e capacitados que te ajudarão a encontrar o imóvel dos seus sonhos\r\nAnúncio do corretor de imóveis Rosemary Leônidas Ferreira CRECI: 43921",
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
                    URLsImagens = new List<string> { "https://res.cloudinary.com/fredmarques/image/upload/v1733168202/Rural1Foto1_idqojd.jpg", "https://res.cloudinary.com/fredmarques/image/upload/v1733168201/Rural1Foto2_fkgeas.jpg", "https://res.cloudinary.com/fredmarques/image/upload/v1733168205/Rural1Foto3_jbdep6.jpg", "https://res.cloudinary.com/fredmarques/image/upload/v1733168204/Rural1Foto4_z1eqp5.jpg" },
                    Titulo = "Chacara no interior de Sp entre Jundiaí e Itu (50min de São Paulo) com 6 suítes piscina hidromassagem área gourmet lareira",
                    Descricao = "Referência: 810 - Chacara no interior de Sp entre Jundiaí e Itu (50min de São Paulo)\r\n100m da rodovia, com acesso em estrada asfaltada\r\nGuarita com segurança 24h em frente ao imóvel\r\n\r\n\r\nàrea total do terreno: 4.800 m2\r\nàrea construída: 700 m2\r\n\r\n\r\nImóvel para hospedar 14 pessoas\r\n6 suítes, sendo:\r\n1 suíte master com banheira hidromassagem\r\n2 suites internas\r\n1 suíte externa (frente piscina)\r\n2 demi-suites (banheiros independentes em frente)\r\nMobiliado\r\n8 TVs\r\nCozinha completa\r\nDespensa com geladeira e freezer\r\nàrea interna e externa totalmente mobiliada\r\nàrea de churrasco com forno a lenha\r\nQuiosque\r\nCampo de futebol\r\nPomar formado\r\nPiscina\r\nAquecimento solar\r\n2 poços (sendo um semi artesiano)\r\nàgua potável na casa toda\r\n4 vagas cobertas e mais 6 descobertas\r\n2 banheiros independentes para área da piscina\r\nàrea de depósito separada da casa principal\r\nCanil\r\nCapela\r\nCasa separada para caseiro",
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
                    URLsImagens = new List<string> { "https://res.cloudinary.com/fredmarques/image/upload/v1733181268/Rural2Foto1_ewp5eg.jpg", "https://res.cloudinary.com/fredmarques/image/upload/v1733181268/Rural2Foto2_vh8cqo.jpg", "https://res.cloudinary.com/fredmarques/image/upload/v1733181268/Rural2Foto3_kzedhd.jpg", "https://res.cloudinary.com/fredmarques/image/upload/v1733181268/Rural2Foto4_vsyayl.jpg" },
                    Titulo = "Rural - Fazenda Monte d'Este",
                    Descricao = "OPORTUNIDADE\r\n\r\nVenha desfrutar de momentos inesquecíveis em uma linda chácara para locação definitiva!! Com uma infraestrutura completa e espaços amplos, esta propriedade é perfeita para reunir familiares e amigos em um ambiente tranquilo e cercado pela natureza, podendo ainda ser utilizada para uma clinica de repouso ou algo de interesse comercial.\r\n\r\nA casa principal, conta com 5 quartos, sendo 3 suítes, todos decorados com bom gosto, você e seus convidados terão todo o conforto necessário para descansar e recarregar as energias. As suítes contam com banheiros privativos, proporcionando ainda mais comodidade sem contar a suite master com hidro.\r\n\r\nConta com uma casa de caseiro, com 2 quartos , cozinha, sala, banheiro, lavanderia e varanda\r\n\r\nAs 3 salas espaçosas e aconchegantes são ideais para momentos de descontração e integração. Neles, você poderá aproveitar para assistir a filmes, jogar jogos de tabuleiro ou simplesmente conversar e compartilhar momentos especiais com seus entes queridos.\r\n\r\nPara maior praticidade, a chácara possui 5 banheiros, evitando filas e proporcionando mais conforto para todos. Além disso, há 4 vagas de garagem coberta e podendo superar 30 vagas descobertas, garantindo segurança e comodidade para os veículos de todos os visitantes.\r\n\r\nCom uma área de 16.000 m2 e mais de 800 m² de construção, esse espaço é perfeito para quem busca tranquilidade e privacidade. Aqui, você poderá aproveitar ao máximo a piscina, o jardim e a área gourmet, que conta com churrasqueira , fogão a lenha, forno e um amplo espaço para confraternizações ao ar livre. Conta ainda com uma bela quadra poliesportiva.\r\n\r\nLocalizada em um local privilegiado, a chácara está próxima a áreas verdes, trilhas ecológicas e belas paisagens, proporcionando uma estadia única e revigorante. Além disso, está a poucos minutos do centro de Barão Geraldo e a Unicamp, onde você encontrará uma ampla variedade de comércios, restaurantes e atividades culturais.\r\n\r\nSe você procura um local para relaxar e aproveitar momentos especiais com seus entes queridos, essa chácara é a escolha perfeita. Garanta já a sua reserva e desfrute de uma experiência única em um ambiente acolhedor e repleto de conforto. Entre em contato conosco e agende uma visita para conhecer pessoalmente todos os encantos que essa propriedade tem a oferecer.",
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
                    Area = 260.00,
                    Preco = 1300000.00,
                    Anos = 12,
                    TipoServico = "Comprar",
                    CEP = "13252-744",
                    Rua = "Rua Cinco",
                    Numero = null,
                    Bairro = "Condomínio Itaembu",
                    Cidade = "Itatiba",
                    UnidadeFederativa = "SP",
                    Endereco = "Rua Cinco, S.N.º, Condomínio Itaembu, Itatiba, SP - 13252-744",
                    URLsImagens = new List<string> { "https://res.cloudinary.com/fredmarques/image/upload/v1733181681/Rural3Foto1_agzo7t.jpg", "https://res.cloudinary.com/fredmarques/image/upload/v1733181681/Rural3Foto2_ruoram.jpg", "https://res.cloudinary.com/fredmarques/image/upload/v1733181681/Rural3Foto3_ql2jg4.jpg", "https://res.cloudinary.com/fredmarques/image/upload/v1733181681/Rural3Foto4_utcn48.webp" },
                    Titulo = "Linda Chácara No Condominio Itaembu, Com Vista Para o Lago E por Do Sol.",
                    Descricao = "Linda chácara no Condominio Itaembu, com vista para o lago e por do sol.\r\nTerreno de 5 mil metros, com 246 mts de área construida.\r\nA casa principal e a edícula foram totalmente remodeladas recentemente!\r\nAs janelas e portas são de madeira maciça, na sala principal temos muitas janelas e uma grande porta balcão que garantem uma vista quase 360 maravilhosa e totalmente verde.\r\nAlém disso, a sala principal possui uma grande lareira revestida em pedra que torna o ambiente ainda mais charmoso. Os 2 banheiros da casa principal possuem uma parede de seixos (pedras) e os chuveiros são à gás, o que torna o banho muito mais agradável e com a possibilidade de obter a temperatura desejada.\r\n\r\nO piso de toda a casa é de cimento queimado, com alguns detalhes de ladrilho hidráulico.\r\n\r\nAo redor da casa temos uma grande área revestida com pedra mesclada São Tomé que também revestem os pilares garantindo a beleza e o frescor que esta pedra possui.\r\nA sala possui três ambientes: sala estar com lareira, sala de jantar e cozinha conjugada.\r\n\r\nPossui tres dormitorios, um deles sendo uma suite, com porta balcao para um pateo. O segundo quarto possui porta balcao para a varanda e uma janela para o pateo, O terceiro quarto, possui uma janela para a varanda.\r\n\r\nA vista de ambos os quartos é um espetáculo à parte!\r\n\r\nPossui mais um banheiro completo, com a area do box feito de seicho e pia de madeira rustica.\r\n\r\nA casa conta com uma lavanderia, com entrada independente, fechada com janela de madeira dando para um pateo e porta de madeira.\r\n\r\nA edícula conta com uma grande sala e um banheiro, possui uma linda lareira de metal de canto e uma parede de pedras Sao Thome, garantindo charme e frescor ao ambiente.\r\n\r\nNa parte de baixo do terreno, tem mais uma casa contendo um amplo ambiente com cozinha conjugada e banheiro.\r\nAo lado da casa tem um deposito, e uma bancada para trabalho do lado de fora, totalmente coberta.\r\nPossui um galinheiro, um espaco bem grande cercado para um canil.\r\nTem uma piscina de fibra 12 x 6 de agua salgada.\r\nUma area de churrasqueira, sauna a vapor e um banheiro ao lado.\r\nTem uma grande area verde com alguns pés de banana e muito verde.\r\nO Terreno possui entrada para duas ruas.\r\n\r\nCondomio tem 4 lagos, campo de futebol, duas quadras de beach tenis, quadra poli esportiva/tenis, academia 24 horas, playgroug, salao de festas, area de churrasqueira, varias areas para trilha.\r\n\r\nAgende uma visita nesse paraiso.",
                    AreasComuns = new List<string> { "Vigilância 24h", "Churrasqueira (parrilla)" },
                    Quartos = 4,
                    Suites = 2,
                    Banheiros = 4,
                    Vagas = 10
                },
                new Rural
                {
                    Id = null,
                    Tipo = "Rural",
                    Area = 474.00,
                    Preco = 3700.00,
                    Anos = 14,
                    TipoServico = "Alugar",
                    CEP = "36406-380",
                    Rua = "Rua Geraldo Plaza",
                    Numero = null,
                    Bairro = "Amaro Ribeiro",
                    Cidade = "Conselheiro Lafaiete",
                    UnidadeFederativa = "MG",
                    Endereco = "Rua Geraldo Plaza, S.N.º, Amaro Ribeiro, Conselheiro Lafaiete, MG - 36406-380",
                    URLsImagens = new List<string> { "https://res.cloudinary.com/fredmarques/image/upload/v1733182015/Rural4Foto1_ezztz6.jpg", "https://res.cloudinary.com/fredmarques/image/upload/v1733182015/Rural4Foto2_rzoqfq.jpg", "https://res.cloudinary.com/fredmarques/image/upload/v1733182015/Rural4Foto3_hxghvg.jpg" },
                    Titulo = "Rurais À Venda - Em Amaro Ribeiro",
                    Descricao = "Chácara à venda e locação no bairro Amaro ribeiro, composta por 1.400 m², com poço artesiano, internet fibra óptica, piscina, área gourmet com churrasqueira, 02 residências com 02 banheiro,02 quartos,01 sala,01 cozinha.\r\nChácara Localizada à 1,5 KM do bairro Amaro Ribeiro.\r\n\r\nAgende sua visita com um de nossos corretores através dos nosso contatos.",
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
                    TipoServico = "Alugar",
                    CEP = "07662-870",
                    Rua = "Via de Acesso km 54 Rod Fernão Dias",
                    Numero = null,
                    Bairro = "Terra Preta",
                    Cidade = "Mairiporã",
                    UnidadeFederativa = "SP",
                    Endereco = "Via de Acesso km 54 Rod Fernão Dias, S.N.º, Terra Preta, Mairiporã, SP - 07662-870",
                    URLsImagens = new List<string> { "https://res.cloudinary.com/fredmarques/image/upload/v1733182501/Rural5Foto1_ojbm2v.jpg", "https://res.cloudinary.com/fredmarques/image/upload/v1733182501/Rural5Foto2_gevheq.jpg", "https://res.cloudinary.com/fredmarques/image/upload/v1733182501/Rural5Foto3_udg5rp.jpg", "https://res.cloudinary.com/fredmarques/image/upload/v1733182502/Rural5Foto4_rvmvlm.jpg" },
                    Titulo = "Linda Chácara Mairiporã para Locação!!!",
                    Descricao = "Linda Chácara para Locação em Mairiporã com muito verde e ar puro em volta, vista para as montanhas, só chácaras, com 1.000 m² de terreno e 250 m² aproximadamente de área construída, piscina com hidromassagem, casa avarandada, campo de futebol, pomar, gruta e cascata, salão e área gourmet.\r\n\r\n\r\n\r\nValor de Locação R$ 3.000,00 mensais + IPTU! Baixou o valor hoje R$ 2.700,00!!\r\n\r\nTel: (11) 4381-0946 WhatsApp Comercial",
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
                    Area = 2500.00,
                    Preco = 600000.00,
                    Anos = 7,
                    TipoServico = "Comprar",
                    CEP = "31742-810",
                    Rua = "Rua Pau-Ferro",
                    Numero = null,
                    Bairro = "Solimões",
                    Cidade = "Belo Horizonte",
                    UnidadeFederativa = "MG",
                    Endereco = "Rua Pau-Ferro, S.N.º, Solimões, Belo Horizonte, MG - 31742-810",
                    URLsImagens = new List<string> { "https://res.cloudinary.com/fredmarques/image/upload/v1733243652/Terreno4Foto1_io4n5e.webp", "https://res.cloudinary.com/fredmarques/image/upload/v1733243652/Terreno4Foto2_xxglra.webp", "https://res.cloudinary.com/fredmarques/image/upload/v1733243652/Terreno4Foto3_hyeplh.webp" },
                    Titulo = "Terreno à Venda, 2500 m² por R$ 600.000",
                    Descricao = "Terreno em frente a Escola Municipal Florestan Fernandes, todo murado. terreno plano com 02 portões e canalização do fundo, são 30 metros de frente e 25 de fundo. Terreno Pronto pra construir.! Área com previsão de crescimento, o Governo tem previsão de abrir uma avenida com Investimento de R$ 1 bilhão na região. Melhor opção.",
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
                    URLsImagens = new List<string> { "https://res.cloudinary.com/fredmarques/image/upload/v1733183383/Terreno1Foto1_ldl6fy.webp", "https://res.cloudinary.com/fredmarques/image/upload/v1733183382/Terreno1Foto2_iyzjcl.webp", "https://res.cloudinary.com/fredmarques/image/upload/v1733183380/Terreno1Foto3_rbszkn.webp" },
                    Titulo = "Terreno à venda no condomínio fechado Portal Bragança Horizonte em Bragança Paulista-SP.",
                    Descricao = "Ótima oportunidade de construir a casa dos sonhos nesse terreno com leve aclive em um dos condomínios mais desejados de Bragança.\r\n\r\nCondomínio com infraestrutura completa , próximo dos principais pontos da cidade como Universidade, Lago do Taboão e fácil acesso à Rod. Fernão Dias.\r\n\r\nAgende já sua visita e conheça esse belo terreno.",
                    AreasComuns = new List<string> { "Condomínio Fechado" }
                },
                new Terreno
                {
                    Id = null,
                    Tipo = "Terreno",
                    Area = 173.00,
                    Preco = 140000.00,
                    Anos = 5,
                    TipoServico = "Comprar",
                    CEP = "12900-031",
                    Rua = "Rua Nicolino Nacaratti",
                    Numero = null,
                    Bairro = "Centro",
                    Cidade = "Bragança Paulista",
                    UnidadeFederativa = "SP",
                    Endereco = "Rua Nicolino Nacaratti, S.N.º, Centro, Bragança Paulista, SP - 12900-031",
                    URLsImagens = new List<string> { "https://res.cloudinary.com/fredmarques/image/upload/v1733184210/Terreno2Foto1_k05oyk.jpg", "https://res.cloudinary.com/fredmarques/image/upload/v1733184209/Terreno2Foto2_pfy5zx.jpg", "https://res.cloudinary.com/fredmarques/image/upload/v1733184210/Terreno2Foto3_h2pl2e.jpg" },
                    Titulo = "Terreno a Venda No Residencial Vila Verde Em Bragança Paulista - Sp.",
                    Descricao = "Terreno a venda com área total de 173m2, no Residencial Vila Verde em Bragança Paulista - SP.\r\nPara você que pensa em investir ou construir a casa dos seus sonhos do jeitinho que você sempre quis. E o melhor de tudo é que você pode fazer isso aqui, nesse terreno incrível que está disponível pra você comprar agora!\r\nNão deixe essa oportunidade passar, venha conferir de perto, agende sua visita!!!\r\n\r\n\r\nAs informações estão sujeitas a alterações. Consulte o corretor responsável.",
                    AreasComuns = new List<string> { }
                },
                new Terreno
                {
                    Id = null,
                    Tipo = "Terreno",
                    Area = 3000.00,
                    Preco = 3400000.00,
                    Anos = 2,
                    TipoServico = "Comprar",
                    CEP = "12915-560",
                    Rua = "Estrada Municipal José Vaccari",
                    Numero = null,
                    Bairro = "Serrinha",
                    Cidade = "Bragança Paulista",
                    UnidadeFederativa = "SP",
                    Endereco = "Estrada Municipal José Vaccari, S.N.º, Serrinha, Bragança Paulista, SP - 12915-560",
                    URLsImagens = new List<string> { "https://res.cloudinary.com/fredmarques/image/upload/v1733184648/Terreno3Foto1_cubk3u.jpg", "https://res.cloudinary.com/fredmarques/image/upload/v1733184650/Terreno3Foto2_yfkxav.jpg", "https://res.cloudinary.com/fredmarques/image/upload/v1733184650/Terreno3Foto3_jfq3v0.jpg", "https://res.cloudinary.com/fredmarques/image/upload/v1733184649/Terreno3Foto4_givcyh.jpg" },
                    Titulo = "Lote Pé Na Água Para Construir a Casa Dos Sonhos Em Bragança",
                    Descricao = "LINDO LOTE DENTRO DE CONDOMÍNIO E PÉ NA ÁGUA EM BRAGANÇA PAULISTA .\r\n\r\nLote medindo 3.000 metros\r\nAcesso exclusivo para represa\r\n\r\nCondomínio com pouquíssimos lotes a venda\r\n\r\nPensa em construir sua casa dos sonhos ?\r\nEntão essa é a hora de realizar!\r\n\r\nAgende sua visita conosco e venha conhecer esse lugar encantador !\r\nTeremos prazer em atendê-lo(a)",
                    AreasComuns = new List<string> { }
                },
                new Terreno
                {
                    Id = null,
                    Tipo = "Terreno",
                    Area = 125.00,
                    Preco = 180000.00,
                    Anos = 5,
                    TipoServico = "Comprar",
                    CEP = "23017-325",
                    Rua = "Estrada do Lameirão Pequeno",
                    Numero = 365,
                    Bairro = "Campo Grande",
                    Cidade = "Rio de Janeiro",
                    UnidadeFederativa = "RJ",
                    Endereco = "Estrada do Lameirão Pequeno, 365, Campo Grande, Rio de Janeiro, RJ - 23017-325",
                    URLsImagens = new List<string> { "https://res.cloudinary.com/fredmarques/image/upload/v1733244059/Terreno5Foto1_xkdk2i.webp", "https://res.cloudinary.com/fredmarques/image/upload/v1733244059/Terreno5Foto2_ejhkxs.webp", "https://res.cloudinary.com/fredmarques/image/upload/v1733244061/Terreno5Foto3_iys79w.webp" },
                    Titulo = "Terreno à Venda, 125 m² por R$ 180.000",
                    Descricao = "O CONDOMÍNIO POSSUI CASAS DE ALTO PADRÃO E O TERRENO MEDE APROXIMADAMENTE 7 METROS DE FRENTE E FUNDOS COM 18 METROS NAS LATERAIS.",
                    AreasComuns = new List<string> { "Condomínio Fechado", "Quadra Poliesportiva", "Jardim", "Playground", "Quadra de Tênis" }
                }
            };

            await _Imoveis.InsertManyAsync(imoveisPreDefinidos);
        }
    }
}