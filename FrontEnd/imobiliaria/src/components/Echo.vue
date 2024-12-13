<template>
    <div class="Echo__Container">
        <div class="Echo__Box">
            <div class="Echo__Box__left">
                <h1 class="Echo__box__left__tittle">Você conhece nossas opções de imóveis?</h1>
                <p class="Echo__box__left__text">Você pode vê-los de acordo com o que melhor se adequa à sua pesquisa.
                </p>
            </div>

            <div class="Echo__Box__rigth">
                <!-- Filtros -->
                <div class="filters">
                    <button v-for="category in categories" :key="category"
                        :class="{ 'active': selectedCategory === category }" @click="selectCategory(category)">
                        {{ category }}
                    </button>
                </div>

                <div class="carousel-container">
                    <button class="carousel-button prev" @click="prevSlide"><svg version="1.0"
                            xmlns="http://www.w3.org/2000/svg" width="18px" height="18px"
                            viewBox="0 0 512.000000 512.000000" preserveAspectRatio="xMidYMid meet">

                            <g transform="translate(0.000000,512.000000) scale(0.100000,-0.100000)" fill="#000000"
                                stroke="none">
                                <path d="M3742 5093 c-58 -32 -2590 -2340 -2637 -2404 -28 -38 -30 -47 -30
-129 0 -82 2 -91 30 -129 47 -64 2579 -2372 2637 -2404 80 -43 163 -34 235 28
80 68 97 193 37 276 -16 22 -567 531 -1224 1131 -657 600 -1195 1094 -1195
1098 0 4 543 503 1207 1110 932 851 1212 1112 1228 1145 41 85 17 193 -56 253
-71 59 -154 67 -232 25z" />
                            </g>
                        </svg>
                    </button>

                    <div class="carousel">
                        <div v-for="(Imovel, index) in currentImoveis" :key="Imovel.id" class="carousel-item">
                            <div class="imovel-box" @click="selecionarImovel(Imovel)">
                                <div class="imovel-box-images">
                                    <img v-if="Imovel.urLsImagens && Imovel.urLsImagens.length > 0"
                                        :src="Imovel.urLsImagens[0]" alt="Imagem do imóvel" class="imovel-image" />
                                </div>
                                <div class="imovel-box-txt">
                                    <p><strong>R$</strong> {{ Imovel.preco }}</p>
                                    <p><strong>{{ Imovel.tipo }}</strong></p>
                                    <p>{{ Imovel.rua }}</p>
                                    <p>{{ Imovel.bairro }}, {{ Imovel.cidade }}</p>
                                </div>
                            </div>
                        </div>
                    </div>

                    <button class="carousel-button next" @click="nextSlide"><svg version="1.0"
                            xmlns="http://www.w3.org/2000/svg" width="18px" height="18px"
                            viewBox="0 0 512.000000 512.000000" preserveAspectRatio="xMidYMid meet">

                            <g transform="translate(0.000000,512.000000) scale(0.100000,-0.100000)" fill="#000000"
                                stroke="none">
                                <path d="M1206 5106 c-46 -17 -99 -67 -121 -113 -24 -51 -21 -134 7 -185 16
-30 378 -366 1228 -1141 663 -604 1205 -1102 1205 -1107 0 -5 -542 -503 -1205
-1107 -850 -775 -1212 -1111 -1228 -1141 -28 -51 -31 -134 -7 -186 24 -50 86
-103 137 -116 48 -13 115 -7 156 14 15 8 614 549 1332 1203 1026 935 1309
1199 1324 1230 24 54 24 152 0 206 -14 31 -300 297 -1324 1229 -718 655 -1318
1197 -1334 1205 -41 21 -124 26 -170 9z" />
                            </g>
                        </svg></button>
                </div>
            </div>
        </div>
    </div>
</template>


<script>
export default {
    // Nome do componente
    name: "Echo",
    data() {
        return {
            // Lista de imóveis carregados
            imoveis: [],
            // Lista de imóveis após filtragem
            filteredImoveis: [],
            // Índice atual para controle de navegação no carrossel
            currentIndex: 0,
            // Quantidade máxima de itens por slide no carrossel
            maxItemsPerSlide: 2,
            // Categorias para filtro de imóveis
            categories: ["Todos", "Comprar", "Alugar"],
            // Categoria selecionada para filtro (inicialmente "Todos")
            selectedCategory: "Todos",
        };
    },
    computed: {
        // Computed property para retornar os imóveis filtrados com base na navegação do carrossel
        currentImoveis() {
            // Retorna uma fatia (slice) da lista filtrada com base no índice atual e no número máximo de itens por slide
            return this.filteredImoveis.slice(
                this.currentIndex,
                this.currentIndex + this.maxItemsPerSlide
            );
        },
    },
    methods: {
        // Método para buscar imóveis da API
        async fetchImoveis() {
            // URL da API que retorna a lista de imóveis
            const apiUrl = "https://localhost:7082/Imovel/ListarImoveis";

            try {
                // Faz a requisição GET para buscar os imóveis
                const response = await fetch(apiUrl, {
                    method: "GET",
                    headers: {
                        Accept: "application/json",
                    },
                });

                // Se a resposta não for bem-sucedida, lança um erro
                if (!response.ok) {
                    throw new Error("Erro ao buscar imóveis.");
                }

                // Converte a resposta para JSON e armazena os dados em 'imoveis' e 'filteredImoveis'
                const data = await response.json();
                this.imoveis = data;
                this.filteredImoveis = data;
            } catch (error) {
                // Caso ocorra um erro, exibe no console
                console.error("Erro ao carregar imóveis:", error);
            }
        },

        // Método para selecionar um imóvel e redirecionar para a página de detalhes do imóvel
        selecionarImovel(imovel) {
            // Converte o tipo de imóvel para minúsculo para usar como chave
            const tipoImovel = imovel.tipo.toLowerCase();

            // Define as rotas para cada tipo de imóvel
            const routes = {
                casa: "ViewOneImovelCasa",
                apartamento: "ViewOneImovelApartamento",
                comercial: "ViewOneImovelComercial",
                lote: "ViewOneImovelLote",
                rural: "ViewOneImoveRural",
                terreno: "ViewOneImovelTerreno",
            };

            // A rota é escolhida com base no tipo do imóvel. Se o tipo não existir, usa "ViewOneImovel"
            const route = routes[tipoImovel] || "ViewOneImovel";

            // Redireciona para a página de detalhes do imóvel com o id do imóvel como parâmetro
            this.$router.push({
                name: route,
                query: { id: imovel.id },
            });
        },

        // Método para aplicar o filtro de imóveis com base na categoria selecionada
        filterImoveis() {
            // Filtra os imóveis com base na categoria selecionada
            this.filteredImoveis =
                this.selectedCategory === "Todos"
                    ? this.imoveis // Se for "Todos", exibe todos os imóveis
                    : this.imoveis.filter(
                        (imovel) => imovel.tipoServico === this.selectedCategory
                    );
            // Reseta o índice para 0 ao filtrar
            this.currentIndex = 0;
        },

        // Método para navegar para o slide anterior no carrossel
        prevSlide() {
            // Só permite navegar para o slide anterior se o índice atual for maior que 0
            if (this.currentIndex > 0) {
                this.currentIndex -= this.maxItemsPerSlide;
            }
        },

        // Método para navegar para o próximo slide no carrossel
        nextSlide() {
            // Só permite navegar para o próximo slide se não ultrapassar o número de imóveis filtrados
            if (this.currentIndex + this.maxItemsPerSlide < this.filteredImoveis.length) {
                this.currentIndex += this.maxItemsPerSlide;
            }
        },

        // Método para selecionar uma categoria e aplicar o filtro correspondente
        selectCategory(category) {
            // Atualiza a categoria selecionada
            this.selectedCategory = category;
            // Aplica o filtro após selecionar a categoria
            this.filterImoveis();
        },
    },
    // Método do ciclo de vida do Vue.js que é chamado após o componente ser montado
    mounted() {
        // Chama o método para buscar os imóveis assim que o componente for carregado
        this.fetchImoveis();
    },
};
</script>


<style scoped>
/* Container principal do componente, centraliza o conteúdo */
.Echo__Container {
    width: 100%; /* A largura ocupa 100% do contêiner pai */
    display: flex; /* Usa flexbox para centralizar os itens */
    justify-content: center; /* Centraliza horizontalmente */
    align-items: center; /* Centraliza verticalmente */
    box-sizing: border-box; /* Inclui o padding e a borda no cálculo de largura e altura */
}

/* Caixa principal que contém a estrutura do componente */
.Echo__Box {
    width: 95%; /* Largura de 95% do contêiner pai */
    height: 500px; /* Altura fixa de 500px */
    background-color: #FFF; /* Fundo branco */
    border: 5px solid #ededed; /* Borda cinza clara */
    color: #333; /* Cor do texto escuro */
    padding: 20px; /* Espaçamento interno */
    border-radius: 8px; /* Bordas arredondadas */
    font-size: 1.2em; /* Tamanho da fonte */
    text-align: center; /* Alinha o texto ao centro */
    display: flex; /* Flexbox para arranjar os elementos dentro */
    flex-wrap: wrap; /* Permite que os itens se movam para a linha seguinte */
}

/* Parte esquerda da caixa, com título e texto */
.Echo__Box__left {
    flex: 1; /* Flexível para ocupar o espaço disponível */
    max-width: 40%; /* Limita a largura máxima em 40% */
    height: 100%; /* Ocupa toda a altura */
    display: flex; /* Flexbox para o conteúdo interno */
    flex-direction: column; /* Organiza o conteúdo em coluna */
    justify-content: center; /* Centraliza o conteúdo verticalmente */
    text-align: left; /* Alinha o texto à esquerda */
    padding: 5rem; /* Espaçamento interno */
    gap: 20px; /* Espaçamento entre os elementos */
}

/* Estilo do título dentro da parte esquerda */
.Echo__box__left__tittle {
    max-width: 65%; /* Limita a largura máxima do título */
    font-weight: 600; /* Peso da fonte em negrito */
    font-size: 1.6rem; /* Tamanho da fonte */
}

/* Estilo do texto explicativo dentro da parte esquerda */
.Echo__box__left__text {
    padding-top: 20px; /* Espaçamento superior */
    font-size: 1rem; /* Tamanho da fonte */
}

/* Parte direita da caixa, onde ficam os filtros e o carrossel */
.Echo__Box__rigth {
    flex: 1; /* Flexível para ocupar o espaço disponível */
    max-width: 70%; /* Limita a largura máxima em 70% */
    height: 100%; /* Ocupa toda a altura */
}

/* Estilo dos botões de filtro */
.filters {
    display: flex; /* Flexbox para dispor os botões */
    justify-content: center; /* Centraliza os botões */
    gap: 10px; /* Espaçamento entre os botões */
    margin-bottom: 20px; /* Espaçamento inferior */
}

/* Estilo dos botões de filtro */
.filters button {
    padding: 10px 20px; /* Espaçamento interno */
    border-radius: 5px; /* Bordas arredondadas */
    background-color: #1A5276; /* Cor de fundo do botão */
    color: white; /* Cor do texto */
    font-size: 1rem; /* Tamanho da fonte */
    cursor: pointer; /* Muda o cursor para indicar que o botão é clicável */
    border: none; /* Remove a borda padrão do botão */
}

/* Estilo para o botão de filtro ativo */
.filters button.active {
    font-weight: 600; /* Aumenta o peso da fonte quando ativo */
    background-color: rgb(0, 43, 82); /* Altera a cor de fundo */
}

/* Estilo para o botão de filtro quando o mouse passa por cima */
.filters button:hover {
    background-color: rgb(0, 43, 82); /* Muda a cor de fundo */
    font-weight: 600; /* Mantém o peso da fonte em negrito */
}

/* Remove a borda de foco do botão */
.filters button:focus {
    outline: none;
}

/* Contêiner do carrossel, para controlar a exibição das imagens */
.carousel-container {
    display: flex; /* Flexbox para o carrossel */
    align-items: center; /* Alinha os itens verticalmente */
    justify-content: center; /* Centraliza os itens horizontalmente */
    position: relative; /* Necessário para posicionar os botões de navegação */
    overflow: hidden; /* Oculta os itens fora da área visível */
    width: 100%; /* Ocupa 100% da largura disponível */
}

/* Estilo do carrossel, controla a transição dos itens */
.carousel {
    display: flex; /* Flexbox para os itens do carrossel */
    transition: transform 0.3s ease-in-out; /* Animação suave na transição */
}

/* Estilo de cada item do carrossel */
.carousel-item {
    display: flex; /* Flexbox para centralizar o conteúdo do item */
    justify-content: center; /* Centraliza o conteúdo horizontalmente */
    align-items: center; /* Centraliza o conteúdo verticalmente */
    padding: 10px; /* Espaçamento interno */
    width: 50%; /* Cada item ocupa 50% da largura */
    box-sizing: border-box; /* Inclui padding e borda no cálculo da largura */
}

/* Caixa de cada imóvel dentro do carrossel */
.imovel-box {
    height: 100%; /* Ocupa toda a altura disponível */
    padding: 20px; /* Espaçamento interno */
    border: 3px solid #ededed; /* Borda cinza clara */
    border-radius: 10px; /* Bordas arredondadas */
    display: flex; /* Flexbox para organizar os itens internos */
    flex-direction: column; /* Organiza o conteúdo em coluna */
    justify-content: space-between; /* Espaçamento entre os itens */
    box-sizing: border-box; /* Inclui padding e borda no cálculo da largura */
}

/* Efeito hover na caixa do imóvel */
.imovel-box:hover {
    cursor: pointer; /* Muda o cursor para indicar que é clicável */
    transform: scale(1.02); /* Aumenta ligeiramente a escala para efeito de destaque */
}

/* Estilo para as imagens dos imóveis */
.imovel-box-images {
    display: flex; /* Flexbox para centralizar as imagens */
    justify-content: center; /* Centraliza a imagem horizontalmente */
    align-items: center; /* Centraliza a imagem verticalmente */
    margin-bottom: 15px; /* Espaçamento inferior */
    width: 250px; /* Largura fixa */
    height: 200px; /* Altura fixa */
    overflow: hidden; /* Esconde qualquer parte da imagem que ultrapasse os limites */
    border-radius: 7px; /* Bordas arredondadas */
}

/* Estilo das imagens dos imóveis */
.imovel-image {
    width: 100%; /* A imagem ocupa 100% da largura do contêiner */
    height: 100%; /* A imagem ocupa 100% da altura do contêiner */
    object-fit: cover; /* Cobre toda a área sem distorcer a imagem */
}

/* Estilo para o texto dentro da caixa do imóvel */
.imovel-box-txt {
    font-size: 14px; /* Tamanho da fonte */
    display: flex; /* Flexbox para organizar o conteúdo em coluna */
    flex-direction: column; /* Organiza o texto em coluna */
    justify-content: center; /* Centraliza o conteúdo verticalmente */
    text-align: justify; /* Justifica o texto */
}

/* Estilo para cada parágrafo dentro da caixa de texto do imóvel */
.imovel-box-txt p {
    max-width: 250px; /* Limita a largura dos parágrafos */
}

/* Estilo para os botões de navegação do carrossel */
.carousel-button {
    position: absolute; /* Posicionamento absoluto para sobrepor o carrossel */
    top: 50%; /* Posiciona no meio verticalmente */
    transform: translateY(-50%); /* Centraliza verticalmente */
    background-color: rgba(255, 255, 255, 0.8); /* Cor de fundo semi-transparente */
    color: #333; /* Cor do ícone */
    font-size: 2.5rem; /* Tamanho do ícone */
    border: none; /* Remove a borda do botão */
    cursor: pointer; /* Indica que o botão é clicável */
    display: flex; /* Flexbox para centralizar o conteúdo */
    align-items: center; /* Alinha os itens verticalmente */
    justify-content: center; /* Centraliza os itens horizontalmente */
    padding: 15px; /* Espaçamento interno */
    z-index: 10; /* Garante que o botão fique acima dos outros elementos */
    border-radius: 50%; /* Torna o botão redondo */
    transition: background-color 0.3s ease, transform 0.3s ease; /* Animação para o botão */
    box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1); /* Sombra suave */
    width: 60px; /* Largura fixa */
    height: 60px; /* Altura fixa */
}

/* Estilo para o botão de navegação quando o mouse passa por cima */
.carousel-button:hover {
    background-color: #ededed; /* Muda a cor de fundo */
    transform: translateY(-50%) scale(1.1); /* Aumenta ligeiramente a escala */
}

/* Estilo para o botão de navegação quando pressionado */
.carousel-button:active {
    transform: translateY(-50%) scale(1); /* Reduz a escala para o tamanho original */
}

/* Posicionamento do botão "anterior" do carrossel */
.carousel-button.prev {
    left: 15px; /* Posiciona à esquerda */
}

/* Posicionamento do botão "próximo" do carrossel */
.carousel-button.next {
    right: 15px; /* Posiciona à direita */
}

/* Estilos para a responsividade em telas maiores que 1024px */
@media(max-width: 1024px) {
    .Echo__Box {
        flex-direction: column; /* Muda a direção do layout para coluna */
        padding: 15px; /* Reduz o padding */
        height: 1000px; /* Aumenta a altura */
    }

    .Echo__Box__left {
        max-width: 100%; /* A parte esquerda ocupa 100% */
        padding: 2rem; /* Reduz o padding */
    }

    .Echo__Box__rigth {
        max-width: 100%; /* A parte direita ocupa 100% */
    }

    .carousel-item {
        flex: 0 0 50%; /* Cada item ocupa 50% da largura */
    }

    .carousel-button {
        font-size: 1.5rem; /* Reduz o tamanho da fonte */
    }
}

/* Estilos para a responsividade em telas menores que 768px */
@media(max-width: 768px) {
    .Echo__Container {
        padding: 15px; /* Reduz o padding */
    }

    .Echo__Box {
        width: 100%; /* A largura da caixa ocupa 100% */
        height: auto; /* A altura se ajusta automaticamente */
        border: none; /* Remove a borda */
    }

    .Echo__Box__left {
        max-width: 100%; /* A parte esquerda ocupa 100% */
        padding: 2rem; /* Reduz o padding */
    }

    .Echo__Box__rigth {
        width: 100%; /* A parte direita ocupa 100% */
        height: 200px; /* Define uma altura específica */
    }

    .carousel-item {
        flex: 0 0 100%; /* Cada item ocupa 100% da largura */
    }

    .carousel-button {
        font-size: 1.5rem; /* Reduz o tamanho da fonte */
    }
}

/* Estilos para a responsividade em telas menores que 480px */
@media(max-width: 480px) {
    .Echo__Box {
        width: 100%; /* A largura da caixa ocupa 100% */
        height: auto; /* A altura se ajusta automaticamente */
        flex-direction: column; /* Muda a direção do layout para coluna */
    }

    .Echo__Box__left {
        padding: 1.5rem; /* Reduz o padding */
    }

    .Echo__Box__rigth {
        width: 100%; /* A parte direita ocupa 100% */
        height: 150px; /* Define uma altura específica */
    }

    .carousel-item {
        flex: 0 0 100%; /* Cada item ocupa 100% da largura */
    }

    .carousel-button {
        font-size: 1.5rem; /* Reduz o tamanho da fonte */
    }
}
</style>
