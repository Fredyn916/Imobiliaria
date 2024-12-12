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
    name: "Echo",
    data() {
        return {
            imoveis: [],
            filteredImoveis: [],
            currentIndex: 0,
            maxItemsPerSlide: 2,
            categories: ["Todos", "Comprar", "Alugar"],
            selectedCategory: "Todos",
        };
    },
    computed: {
        currentImoveis() {
            return this.filteredImoveis.slice(
                this.currentIndex,
                this.currentIndex + this.maxItemsPerSlide
            );
        },
    },
    methods: {
        async fetchImoveis() {
            const apiUrl = "https://localhost:7082/Imovel/ListarImoveis";

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
            } catch (error) {
                console.error("Erro ao carregar imóveis:", error);
            }
        },

        selecionarImovel(imovel) {
            const tipoImovel = imovel.tipo.toLowerCase();

            const routes = {
                casa: "ViewOneImovelCasa",
                apartamento: "ViewOneImovelApartamento",
                comercial: "ViewOneImovelComercial",
                lote: "ViewOneImovelLote",
                rural: "ViewOneImoveRural",
                terreno: "ViewOneImovelTerreno",
            };

            const route = routes[tipoImovel] || "ViewOneImovel";

            this.$router.push({
                name: route,
                query: { id: imovel.id },
            });
        },

        filterImoveis() {
            this.filteredImoveis =
                this.selectedCategory === "Todos"
                    ? this.imoveis
                    : this.imoveis.filter(
                        (imovel) => imovel.tipoServico === this.selectedCategory
                    );
            this.currentIndex = 0;
        },

        prevSlide() {
            if (this.currentIndex > 0) {
                this.currentIndex -= this.maxItemsPerSlide;
            }
        },

        nextSlide() {
            if (this.currentIndex + this.maxItemsPerSlide < this.filteredImoveis.length) {
                this.currentIndex += this.maxItemsPerSlide;
            }
        },

        selectCategory(category) {
            this.selectedCategory = category;
            this.filterImoveis();
        },
    },
    mounted() {
        this.fetchImoveis();
    },
};
</script>


<style scoped>
.Echo__Container {
    width: 100%;
    display: flex;
    justify-content: center;
    align-items: center;
    box-sizing: border-box;
}

.Echo__Box {
    width: 95%;
    height: 500px;
    background-color: #FFF;
    border: 5px solid #ededed;
    color: #333;
    padding: 20px;
    border-radius: 8px;
    font-size: 1.2em;
    text-align: center;
    display: flex;
    flex-wrap: wrap;
}

.Echo__Box__left {
    flex: 1;
    max-width: 40%;
    height: 100%;
    display: flex;
    flex-direction: column;
    justify-content: center;
    text-align: left;
    padding: 5rem;
    gap: 20px;
}

.Echo__box__left__tittle {
    max-width: 65%;
    font-weight: 600;
    font-size: 1.6rem;
}

.Echo__box__left__text {
    padding-top: 20px;
    font-size: 1rem;
}

.Echo__Box__rigth {
    flex: 1;
    max-width: 70%;
    height: 100%;
}

.filters {
    display: flex;
    justify-content: center;
    gap: 10px;
    margin-bottom: 20px;
}


.filters button {
    padding: 10px 20px;
    border-radius: 5px;
    background-color: #1A5276;
    color: white;
    font-size: 1rem;
    cursor: pointer;
    border: none;
}

.filters button.active {
    font-weight: 600;
    background-color: rgb(0, 43, 82);
}

.filters button:hover {
    background-color: rgb(0, 43, 82);
    font-weight: 600;
}

.filters button:focus {
    outline: none;
}

.carousel-container {
    display: flex;
    align-items: center;
    justify-content: center;
    position: relative;
    overflow: hidden;
    width: 100%;
}

.carousel {
    display: flex;
    transition: transform 0.3s ease-in-out;
}

.carousel-item {
    display: flex;
    justify-content: center;
    align-items: center;
    padding: 10px;
    width: 50%;
    box-sizing: border-box;
}

.imovel-box {
    height: 100%;
    padding: 20px;
    border: 3px solid #ededed;
    border-radius: 10px;
    display: flex;
    flex-direction: column;
    justify-content: space-between;
    box-sizing: border-box;
}

.imovel-box:hover {
    cursor: pointer;
    transform: scale(1.02);
}

.imovel-box-images {
    display: flex;
    justify-content: center;
    align-items: center;
    margin-bottom: 15px;
    width: 250px;
    height: 200px;
    overflow: hidden;
    border-radius: 7px;
}

.imovel-image {
    width: 100%;
    height: 100%;
    object-fit: cover;
}


.imovel-box-txt {
    font-size: 14px;
    display: flex;
    flex-direction: column;
    justify-content: center;
    text-align: justify;
}

.imovel-box-txt p{
    max-width: 250px;
}

.carousel-button {
    position: absolute;
    top: 50%;
    transform: translateY(-50%);
    background-color: rgba(255, 255, 255, 0.8);
    color: #333;
    font-size: 2.5rem;
    border: none;
    cursor: pointer;
    display: flex;
    align-items: center;
    justify-content: center;
    padding: 15px;
    z-index: 10;
    border-radius: 50%;
    transition: background-color 0.3s ease, transform 0.3s ease;
    box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
    width: 60px;
    height: 60px;
}

.carousel-button:hover {
    background-color: #ededed;
    transform: translateY(-50%) scale(1.1);
}

.carousel-button:active {
    transform: translateY(-50%) scale(1);
}

.carousel-button.prev {
    left: 15px;
}

.carousel-button.next {
    right: 15px;
}

@media(max-width: 1024px) {
    .Echo__Box {
        flex-direction: column;
        padding: 15px;
        height: 1000px;
    }

    .Echo__Box__left {
        max-width: 100%;
        padding: 2rem;
    }

    .Echo__Box__rigth {
        max-width: 100%;
    }

    .carousel-item {
        flex: 0 0 50%;
    }

    .carousel-button {
        font-size: 1.5rem;
    }
}

@media(max-width: 768px) {
    .Echo__Container {
        padding: 15px;
    }

    .Echo__Box {
        width: 100%;
        height: auto;
        border: none;
    }

    .Echo__Box__left {
        max-width: 100%;
        padding: 2rem;
    }

    .Echo__Box__rigth {
        width: 100%;
        height: 200px;
    }

    .carousel-item {
        flex: 0 0 100%;
    }

    .carousel-button {
        font-size: 1.5rem;
    }
}

@media(max-width: 480px) {
    .Echo__Box {
        width: 100%;
        height: auto;
        flex-direction: column;
    }

    .Echo__Box__left {
        padding: 1.5rem;
    }

    .Echo__Box__rigth {
        width: 100%;
        height: 150px;
    }

    .carousel-item {
        flex: 0 0 100%;
    }

    .carousel-button {
        font-size: 1.5rem;
    }
}
</style>
