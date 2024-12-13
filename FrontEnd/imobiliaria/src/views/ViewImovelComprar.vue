<template>
    <div ref="targetSection">
        <div class="container">
            <!-- Filtro de busca -->
            <div class="filter__container">
                <input type="text" id="searchBar" v-model="searchQuery" @input="filterImoveis"
                    placeholder="Digite a cidade, bairro ou Rua..." class="filter__input" />
            </div>

            <!-- Filtro por tipo de imóvel -->
            <div class="filter__container">
                <select id="categoryFilter" v-model="selectedCategory" @change="filterImoveis" class="filter__select">
                    <option value="">Todos os tipos</option>
                    <option value="Apartamento">Apartamento</option>
                    <option value="Casa">Casa</option>
                    <option value="Lote">Lote</option>
                    <option value="Comercial">Comercial</option>
                    <option value="Rural">Rural</option>
                    <option value="Terreno">Terreno</option>
                </select>
            </div>

            <!-- Filtro por faixa de preço -->
            <div class="filter__container">
                <label for="priceFilter">Preço:</label>
                <input type="number" id="minPrice" v-model.number="minPrice" placeholder="Preço mínimo"
                    class="filter__input" @input="filterImoveis" />
                <input type="number" id="maxPrice" v-model.number="maxPrice" placeholder="Preço máximo"
                    class="filter__input" @input="filterImoveis" />
            </div>

            <div class="filter__container">
                <button @click="clearFilters" class="clear__filters__btn">Limpar filtros</button>
            </div>
        </div>

        <!-- Lista de imóveis -->
        <div class="Imovel__container">
            <ul class="imovel__container__list">
                <li v-for="Imovel in filteredImoveis" :key="Imovel.id" class="imovel__container__item"
                    @click="selecionarImovel(Imovel)">
                    <div class="Imovel__Container__internal__container">
                        <div class="Imovel__Container__box__Left">
                            <img v-if="Imovel.urLsImagens && Imovel.urLsImagens.length > 0" :src="Imovel.urLsImagens[0]"
                                alt="Imagem do imóvel" class="imovel-image" />
                        </div>
                        <div class="Imovel__Container__box__Right">
                            <div class="Imovel__item__container">
                                <div class="Imove__item__container__item">
                                    <div class="Imovel__preco">
                                        <h2><strong>R$ {{ formatPrice(Imovel.preco) }}</strong></h2>
                                    </div>

                                    <div class="Imovel__TipoServico">
                                        <p>{{ Imovel.tipoServico }}</p>
                                    </div>
                                </div>
                                <div class="Imove__item__container__item">
                                    <div class="Imovel__rua">
                                        <p>{{ Imovel.rua }}</p>
                                    </div>
                                    <div class="Imovel__endereco">
                                        <p>{{ Imovel.bairro }}, {{ Imovel.cidade }}</p>
                                    </div>
                                </div>
                                <div class="Imovel__areasComuns">
                                    <div class="Imovel__area">
                                        <p>{{ Imovel.area }} m²</p>
                                    </div>
                                    <ul class="Ul__AreasComuns">
                                        <li v-for="area in Imovel.areasComuns" :key="area">
                                            {{ area }}
                                        </li>
                                    </ul>
                                </div>
                                <div class="Imovel__descricao">
                                    <p>{{ Imovel.descricao }}</p>
                                </div>

                                <div class="Imove__item__container__item">
                                    <div class="Imovel__box__rigth__buttons">

                                        <button @click="openPopup2">WhatsApp</button>
                                        <button @click="openPopup">Contatar</button>

                                        <div v-if="isPopupVisible" class="popup">
                                            <span @click="closePopup" class="close-btn">&times;</span>
                                            <div class="contact__box">
                                                <div class="internal__contact__box">
                                                    <h3>Contate o Anunciante</h3>
                                                    <form @submit.prevent="enviarMensagem" class="contact-form">
                                                        <div class="form-group">
                                                            <input type="email" id="email" v-model="email"
                                                                placeholder="E-mail" required />
                                                        </div>
                                                        <div class="name__telefon__container">
                                                            <div class="form-group1">
                                                                <input type="text" id="nome" v-model="nome"
                                                                    placeholder="Nome" required />
                                                            </div>
                                                            <div class="form-group1">
                                                                <input type="text" id="telefone" v-model="telefone"
                                                                    placeholder="Telefone" required />
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <textarea id="mensagem" v-model="mensagem"
                                                                placeholder="Mensagem" required></textarea>
                                                        </div>
                                                        <button type="submit" class="submit-btn">Contatar </button>
                                                        <p class="terms">Ao enviar, você está aceitando os <a
                                                                href="#">Termos e Condições de uso</a>
                                                            e
                                                            as <a href="#">Políticas de Privacidade</a></p>
                                                    </form>
                                                </div>
                                            </div>
                                        </div>

                                        <div v-if="isPopupVisible" class="overlay" @click="closePopup"></div>
                                    </div>
                                </div>
                            </div>


                        </div>
                    </div>
                </li>

            </ul>
        </div>

        <!-- Botão fixo de rolagem -->
        <button @click="smoothScrollToSection" class="buttontosection">
            <svg version="1.0" xmlns="http://www.w3.org/2000/svg" width="18px" height="18px"
                viewBox="0 0 512.000000 512.000000" preserveAspectRatio="xMidYMid meet">

                <g transform="translate(0.000000,512.000000) scale(0.100000,-0.100000)" fill="#000000" stroke="none">
                    <path d="M2505 5101 c-16 -10 -512 -502 -1102 -1092 -855 -857 -1072 -1080
  -1078 -1106 -9 -44 18 -97 60 -117 29 -14 107 -16 624 -16 l591 0 0 -1335 c0
  -1132 2 -1341 14 -1370 29 -69 -22 -66 962 -63 l886 3 29 33 29 32 0 1350 0
  1350 591 0 c517 0 595 2 624 16 42 20 69 73 60 117 -6 26 -225 250 -1083 1109
  -592 593 -1091 1085 -1108 1093 -42 20 -63 19 -99 -4z" />
                </g>
            </svg>
        </button>
    </div>
</template>

<script>
export default {
    name: "ViewImovelComprar",
    data() {
        return {
            imoveis: [],
            searchQuery: "",
            selectedCategory: "",
            selectedServiceType: "",
            minPrice: null,
            maxPrice: null,
            filteredImoveis: [],
            selectedImovelId: null,
            isPopupVisible: null,
            status: '',
            search: '',
            type: ''
        };
    },

    mounted() {
        this.fetchImoveis();
    },

    watch: {
        '$route.query': {
            handler: 'applyFiltersFromQuery',
            immediate: true
        }
    },

    methods: {
        applyFiltersFromQuery() {
            this.status = this.$route.query.status || '';
            this.type = this.$route.query.type || '';
            this.search = this.$route.query.search || '';

            this.selectedServiceType = this.status;
            this.selectedCategory = this.type;
            this.searchQuery = this.search;

            this.filterImoveis();
        },

        clearFilters() {
            this.searchQuery = "";
            this.selectedCategory = "";
            this.selectedServiceType = "";
            this.minPrice = null;
            this.maxPrice = null;
            this.filterImoveis();
        },

        async fetchImoveis() {
            const apiUrl = "https://localhost:7082/Imovel/ListarImoveisPorTipoServico?tipoServico=Comprar";
            try {
                const response = await fetch(apiUrl, {
                    method: "GET",
                    headers: {
                        Accept: "application/json",
                    },
                });

                if (!response.ok) {
                    throw new Error("Erro ao buscar imóveis.");
                }

                const data = await response.json();
                this.imoveis = data;
                this.filteredImoveis = data;
                this.applyFiltersFromQuery(); // Aplicar filtros depois de carregar os imóveis
            } catch (error) {
                console.error("Erro ao carregar imóveis:", error);
            }
        },

        filterImoveis() {
            this.filteredImoveis = this.imoveis.filter((imovel) => {
                const matchesCategory = this.selectedCategory
                    ? imovel.tipo.toLowerCase().includes(this.selectedCategory.toLowerCase())
                    : true;

                const matchesSearch = this.searchQuery
                    ? imovel.cidade.toLowerCase().includes(this.searchQuery.toLowerCase()) ||
                    imovel.bairro.toLowerCase().includes(this.searchQuery.toLowerCase()) ||
                    imovel.rua.toLowerCase().includes(this.searchQuery.toLowerCase())
                    : true;

                const matchesPrice =
                    (!this.minPrice || imovel.preco >= this.minPrice) &&
                    (!this.maxPrice || imovel.preco <= this.maxPrice);

                const matchesServiceType = this.selectedServiceType
                    ? imovel.tipoServico.toLowerCase().includes(this.selectedServiceType.toLowerCase())
                    : true;

                return matchesCategory && matchesSearch && matchesPrice && matchesServiceType;
            });
        },

        formatPrice(value) {
            if (!value) return "0";
            return value
                .toLocaleString("pt-BR", { style: "currency", currency: "BRL" })
                .replace("R$", "")
                .trim();
        },

        selecionarImovel(imovel) {
            this.selectedImovelId = imovel.id;
            const tipoImovel = imovel.tipo.toLowerCase();

            const routeMap = {
                casa: 'ViewOneImovelCasa',
                apartamento: 'ViewOneImovelApartamento',
                comercial: 'ViewOneImovelComercial',
                lote: 'ViewOneImovelLote',
                rural: 'ViewOneImoveRural',
                terreno: 'ViewOneImovelTerreno',
            };

            const routeName = routeMap[tipoImovel];
            if (routeName) {
                this.$router.push({
                    name: routeName,
                    query: { id: this.selectedImovelId },
                });
            }
        },

        smoothScrollToSection() {
            const section = this.$refs.targetSection;
            const targetPosition = section.offsetTop;
            const startPosition = window.pageYOffset;
            const distance = targetPosition - startPosition;
            const duration = 1000;
            let start = null;

            const step = (timestamp) => {
                if (!start) start = timestamp;
                const progress = timestamp - start;
                const percentage = Math.min(progress / duration, 1);
                window.scrollTo(0, startPosition + distance * percentage);

                if (progress < duration) {
                    window.requestAnimationFrame(step);
                }
            };

            window.requestAnimationFrame(step);
        },
    },
};
</script>


<style scoped>
/* Aplica um comportamento de rolagem suave em todo o documento */
html {
    scroll-behavior: smooth;
}

/* Define a fonte padrão da página */
body {
    font-family: "Funnel Display", sans-serif;
}

/* Estilo do botão fixo na tela */
.buttontosection {
    position: fixed;
    /* Fixa o botão no canto da tela */
    bottom: 20px;
    right: 20px;
    width: 60px;
    height: 60px;
    font-size: 1.8rem;
    background-color: #fff;
    border: none;
    border-radius: 50%;
    cursor: pointer;
    box-shadow: 0px 4px 6px rgba(0, 0, 0, 0.1);
    transition: transform 0.3s ease, background-color 0.3s ease;
    /* Transição para o efeito de hover */
    border: 1px solid black;
    /* Borda preta */
}

/* Efeito de hover no botão */
.buttontosection:hover {
    transform: scale(1.1);
    /* Aumenta o botão */
    background-color: #f0f0f0;
    /* Muda a cor do fundo */
}

/* Estilo da container que contém os filtros */
.container {
    display: flex;
    padding-inline: 3rem;
    margin: 20px;
    gap: 15px;
}

/* Estilo do contêiner de filtros */
.filter__container {
    display: flex;
    gap: 10px;
}

/* Estilo do campo de entrada de filtro */
.filter__input {
    width: 100%;
    height: 90%;
    padding: 12px;
    border-radius: 8px;
    border: 1px solid #7c98a7;
    font-size: 1rem;
}

/* Estilo do seletor de filtro */
.filter__select {
    width: 100%;
    height: 90%;
    padding: 0.90rem 1rem;
    border-radius: 8px;
    border: 1px solid #7c98a7;
    font-size: 1rem;
    background: #fff;
    font-family: "Funnel Display", sans-serif;
    font-weight: 600;
    color: #333;
}

/* Estilo do botão de limpar filtros */
.clear__filters__btn {
    padding: 12px;
    width: 100%;
    height: 90%;
    background-color: #ff4c4c;
    /* Cor vermelha */
    color: #ffffff;
    border: none;
    border-radius: 8px;
    cursor: pointer;
    font-size: 16px;
    font-weight: bold;
    transition: background-color 0.3s, transform 0.3s;
    box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
}

/* Efeito de hover no botão de limpar filtros */
.clear__filters__btn:hover {
    background-color: #e04343;
    /* Muda a cor para um tom mais escuro */
    transform: translateY(-2px);
    /* Move o botão para cima */
}

/* Estilo do contêiner de imóveis */
.Imovel__container {
    width: 100%;
}

/* Contêiner interno de imóveis, permitindo layout flexível */
.Imovel__Container__internal__container {
    display: flex;
    flex-wrap: wrap;
    /* Permite que os itens se ajustem em várias linhas */
}

/* Estilo do lado esquerdo do item de imóvel */
.Imovel__Container__box__Left {
    max-width: 30%;
    max-height: 100%;
    display: flex;
}

/* Estilo da imagem no lado esquerdo */
.Imovel__Container__box__Left img {
    width: 100%;
    min-width: 400px;
    max-width: 400px;
    height: auto;
    /* Mantém a proporção da imagem */
    max-height: 300px;
    border-top-left-radius: 10px;
    border-bottom-left-radius: 10px;
}

/* Estilo do lado direito do item de imóvel */
.Imovel__Container__box__Right {
    flex: 2;
    max-width: 70%;
    padding: 1rem;
    background: #fff;
}

/* Estilo do contêiner de cada item de imóvel */
.Imovel__item__container {
    display: flex;
    flex-direction: column;
    gap: 20px;
}

/* Estilo da descrição do imóvel */
.Imovel__descricao {
    max-height: 17px;
    overflow: hidden;
    /* Oculta o conteúdo que ultrapassa o limite */
}

/* Estilo da lista de imóveis */
.imovel__container__list {
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
    gap: 20px;
    padding: 0;
    padding-bottom: 20px;
}

/* Estilo de cada item dentro da lista de imóveis */
.imovel__container__item {
    width: 95%;
    max-width: 100%;
    max-height: 400px;
    height: auto;
    border: 2px solid #ededed;
    color: #000;
    border-radius: 10px;
    list-style: none;
    overflow: hidden;
}

/* Estilo do texto dentro dos itens da lista de imóveis */
.Imove__item__container__item p,
li {
    font-size: 13px;
}

/* Efeito de hover nos itens da lista de imóveis */
.imovel__container__item:hover {
    cursor: pointer;
}

/* Estilo da seção de áreas comuns */
.Imovel__areasComuns {
    display: flex;
    gap: 20px;
}

/* Estilo da lista de áreas comuns */
.Ul__AreasComuns {
    display: flex;
    gap: 20px;
    list-style: none;
}

/* Estilo dos botões no lado direito do item de imóvel */
.Imovel__box__rigth__buttons {
    width: 100%;
    height: auto;
    border-top: 2px solid #ededed;
    display: flex;
    justify-content: end;
    gap: 20px;
}

/* Estilo dos botões do lado direito */
.Imovel__box__rigth__buttons button {
    margin-top: 10px;
    background-color: rgb(0, 43, 82);
    /* Cor azul */
    padding: 0.90rem 1rem;
    border-radius: 8px;
    border: none;
    color: #FFF;
    transition: .3S;
}

/* Efeito de hover nos botões do lado direito */
.Imovel__box__rigth__buttons button:hover {
    background-color: #1A5276;
    /* Cor azul mais escura */
    transform: scale(1.1);
    /* Aumenta o botão */
}

/* Estilo da rua no imóvel */
.Imovel__rua p {
    color: #1f1e1e;
    font-weight: 600;
    font-size: 18px;
}

/* Estilo do label dentro do filtro */
.filter__container label {
    width: 30%;
    height: 90%;
    padding: 0.8rem;
    border-radius: 9px;
}

/* Estilos responsivos para telas entre 1024px e 1600px */
@media (min-width: 1024px) and (max-width: 1600px) {
    .imovel__container__item {
        width: 95%;
        max-width: 100%;
        max-height: 400px;
        height: auto;
        color: #000;
        border-radius: 10px;
        list-style: none;
    }
}

/* Estilos responsivos para telas entre 768px e 1024px */
@media (min-width: 768px) and (max-width: 1024px) {
    .Imovel__Container__box__Left img {
        width: 100%;
        max-width: 400px;
        height: 100%;
        max-height: 400px;
    }

    .imovel__container__item {
        width: 95%;
        max-width: 100%;
        max-height: 800px;
        height: auto;
        color: #000;
        border-radius: 10px;
        list-style: none;
    }

    .Imovel__areasComuns {
        display: flex;
        flex-direction: column;
    }

    .Ul__AreasComuns {
        display: flex;
        flex-direction: column;
        gap: 20px;
        list-style: none;
    }
}

/* Estilos responsivos para telas menores que 768px */
@media(max-width: 768px) {
    .container {
        padding: 10px;
        justify-content: center;
    }

    .Imovel__Container__internal__container {
        flex-direction: column;
    }

    .Imovel__Container__box__Left,
    .Imovel__Container__box__Right {
        max-width: 100%;
        flex: none;
    }

    .Imovel__Container__box__Left img {
        width: 100%;
        max-width: 100%;
        height: 100%;
        max-height: 400px;
        border-radius: 10px;
    }

    .imovel__container__item {
        width: 100%;
    }

    .imovel__container__list {
        padding: 0 20px;
    }

    .buttontosection {
        right: 10px;
        bottom: 10px;
    }

    .Imovel__areasComuns {
        flex-direction: column;
    }

    .Ul__AreasComuns {
        flex-direction: column;
    }
}
</style>
