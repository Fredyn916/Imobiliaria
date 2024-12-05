<template>
    <div class="Echo__Container">
        <div class="Echo__Box">
            <div class="Echo__Box__left">
                <h1 class="Echo__box__left__tittle">Você conhece nossas opções de imóveis novos?</h1>
                <p class="Echo__box__left__text">Você pode vê-los de acordo com o estágio da obra que melhor se adequa à
                    sua pesquisa.</p>
                <button class="Echo__box__left__btn">Mais Empreendimentos em obras</button>
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
                    <button class="carousel-button prev" @click="prevSlide">❮</button>

                    <div class="carousel">
                        <div v-for="(Imovel, index) in currentImoveis" :key="Imovel.id" class="carousel-item">
                            <div class="imovel-box">
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

                    <button class="carousel-button next" @click="nextSlide">❯</button>
                </div>
            </div>
        </div>
    </div>
</template>



<script>
export default {
    name: 'Echo',
    data() {
        return {
            imoveis: [],
            filteredImoveis: [],
            currentIndex: 0,
            maxItemsPerSlide: 2,
            categories: ['Todos', 'Comprar', 'Alugar'],
            selectedCategory: 'Todos',
        };
    },
    computed: {
        currentImoveis() {
            return this.filteredImoveis.slice(this.currentIndex, this.currentIndex + this.maxItemsPerSlide);
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
                    throw new Error('Erro ao buscar imóveis.');
                }

                const data = await response.json();
                console.log(data)
                this.imoveis = data;
                this.filteredImoveis = data;

            } catch (error) {
                console.error('Erro ao carregar imóveis:', error);
            }
        },

        filterImoveis() {
            if (this.selectedCategory === 'Todos') {
                this.filteredImoveis = this.imoveis;
            } else {
                this.filteredImoveis = this.imoveis.filter(imovel => imovel.tipoServico === this.selectedCategory);
            }
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
    font-size: 1rem;
}

.Echo__box__left__btn {
    max-width: 60%;
    height: 50px;
    border: 1px solid #333;
    background-color: #FFF;
    border-radius: 10px;
    font-weight: bold;
    cursor: pointer;
    margin-top: 20px;
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
    width: 100%;
    height: 100%;
    padding: 20px;
    border: 3px solid #ededed;
    border-radius: 10px;
    display: flex;
    flex-direction: column;
    justify-content: space-between;
    box-sizing: border-box;
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

.carousel-button {
    position: absolute;
    top: 50%;
    transform: translateY(-50%);
    background-color: #ededed;
    color: #333;
    font-size: 2rem;
    border: none;
    cursor: pointer;
    padding: 10px;
    z-index: 1;
    border-radius: 30%;
}

.carousel-button.prev {
    left: 0;
}

.carousel-button.next {
    right: 0;
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
