<template>
    <div class="Hero__bg__container">
        <div class="Hero__bg__Tittle">
            Você muda, sua vida muda
        </div>

        <div class="Hero__bg__container__box1">
            <button class="Hero__bg__container__box1__btn" @click="setStatus('Alugar')">
                Alugar
            </button>
            <button class="Hero__bg__container__box1__btn" @click="setStatus('Comprar')">
                Comprar
            </button>
            <button class="Hero__bg__container__box1__btn" @click="setStatus('Todos')">
                Todos
            </button>
        </div>

        <div class="Hero__bg__container__box2">
            <div class="Hero__bg__container__box2__label">
                <select id="opcoes" name="opcoes" v-model="selectedType">
                    <option value="Casa">Casa</option>
                    <option value="Apartamento">Apartamento</option>
                    <option value="Lote">Lote</option>
                    <option value="Comercial">Comercial</option>
                    <option value="Rural">Rural</option>
                </select>
            </div>

            <div class="Hero__bg__container__box2__item1">
                <input type="search" id="pesquisa" name="pesquisa" v-model="searchQuery"
                    placeholder="Digite cidades, bairros ou características para pesquisar..." />
            </div>

            <div class="Hero__bg__container__box2__item2">
                <button class="Hero__bg__container__box2__Search__Btn" @click="navigateWithParams">
                    Buscar
                </button>
            </div>
        </div>
    </div>
</template>

<script>
export default {
    name: "Hero",
    data() {
        return {
            selectedStatus: "",
            selectedType: "",
            searchQuery: "",
        };
    },
    methods: {
        setStatus(status) {
            this.selectedStatus = status;
        },
        navigateWithParams() {

            this.$router.push({
                name: "ViewImovel",
                query: { status: this.selectedStatus, type: this.selectedType, search: this.searchQuery },
            });
        },
    },
    mounted() {
        // Adiciona a classe `active` ao botão selecionado
        const buttons = document.querySelectorAll(".Hero__bg__container__box1__btn");
        buttons.forEach((button) => {
            button.addEventListener("click", () => {
                buttons.forEach((btn) => btn.classList.remove("active"));
                button.classList.add("active");
            });
        });
    },
};
</script>


<style scoped>
.Hero__bg__container {
    text-align: center;
    width: 100%;
    max-width: 1000px;
    margin: 0 auto;
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
}

.Hero__bg__Tittle {
    max-width: 900px;
    font-size: 2.5rem;
    font-weight: 600;
    margin-top: -30px;
    color: #f3f7f8;
}

.Hero__bg__container__box1 {
    background-color: #FFF;
    width: 90%;
    height: 70px;
    border-top-left-radius: 15px;
    border-top-right-radius: 15px;
    display: flex;
    align-items: center;
    justify-content: space-around;
    margin-top: 50px;
}

.Hero__bg__container__box1__btn {
    width: 28%;
    height: 50px;
    background-color: #FFF;
    color: #2C3E50;
    font-size: 16px;
    font-weight: bold;
    border: none;
    border-radius: 15px;
    cursor: pointer;
    text-align: center;
    display: inline-block;
    position: relative;
    transition: background-color 0.3s ease, transform 0.2s ease;
    line-height: 50px;
}

.Hero__bg__container__box1__btn:after {
    content: "";
    position: absolute;
    bottom: 5px;
    left: 0;
    width: 0%;
    height: 2px;
    background-color: black;
    transition: width 0.3s ease;
}

.Hero__bg__container__box1__btn.active {
    background-color: #f3f7f8;
    transform: scale(1);
}

.Hero__bg__container__box1__btn.active:after {
    width: 100%;
}

.Hero__bg__container__box2 {
    background-color: #FFF;
    width: 90%;
    height: 80px;
    border-bottom-left-radius: 15px;
    border-bottom-right-radius: 15px;
    display: flex;
    justify-content: space-around;
}

.Hero__bg__container__box2__label {
    width: 20%;
    display: flex;
    align-items: center;
    justify-content: center;
}

.Hero__bg__container__box2__item1 {
    width: 60%;
    display: flex;
    align-items: center;
    justify-content: center;
}

.Hero__bg__container__box2__item2 {
    width: 15%;
    display: flex;
    align-items: center;
    justify-content: center;
}

.Hero__bg__container__box2__label select {
    width: 100%;
    height: 50px;
    padding: 8px;
    border: 1px solid #4D5656;
    color: #2C3E50;
    border-radius: 8px;
    font-size: 16px;
    cursor: pointer;
    background-color: #f9f9f9;
    box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
}

input[type="search"] {
    width: 100%;
    height: 50px;
    padding: 10px;
    font-size: 16px;
    border: 1px solid #ccc;
    border-radius: 10px;
    outline: none;
    transition: border-color 0.3s;
}

input[type="search"]:focus {
    border-color: #007BFF;
    box-shadow: 0 0 5px rgba(0, 123, 255, 0.5);
}

.Hero__bg__container__box2__Search__Btn {
    background-color: rgb(0, 43, 82);
    border: none;
    color: #FFF;
    padding: 1.2rem 3em;
    text-align: center;
    cursor: pointer;
    border-radius: 10px;
    transition: background-color 0.3s;
    transition: .3s;
}

.Hero__bg__container__box2__Search__Btn:hover {
    background-color: #1A5276;
    transform: scale(1.05);
    font-weight: bold;
}

@media (min-width: 0px) and (max-width: 768px) {
    .Hero__bg__Tittle {
        display: block;
        padding-top: 80px;
    }

    .Hero__bg__container {
        display: flex;
        flex-direction: column;
        text-align: center;
        align-items: center;
        width: 100%;
        padding: 0 10px;
    }

    .Hero__bg__container__box1 {
        width: 100%;
        height: auto;
        margin-top: 20px;
        display: flex;
        justify-content: space-between;
        flex-wrap: wrap;
        padding: 0 10px;
    }

    .Hero__bg__container__box1__btn {
        width: 33%;
        height: 50px;
        margin-bottom: 10px;
        font-size: 14px;
        border-radius: 10px;
        text-align: center;
        line-height: 50px;
    }

    .Hero__bg__container__box2 {
        width: 90%;
        height: auto;
        border-bottom-left-radius: 15px;
        border-bottom-right-radius: 15px;
        padding: 15px;
        display: flex;
        flex-direction: column;
        align-items: center;
        justify-content: space-between;
    }

    .Hero__bg__container__box2__label,
    .Hero__bg__container__box2__item1,
    .Hero__bg__container__box2__item2 {
        width: 100%;
        margin-bottom: 10px;
    }

    .Hero__bg__container__box2__label select {
        width: 100%;
        height: 50px;
        padding: 8px;
        font-size: 14px;
        border-radius: 8px;
        border: 1px solid #ccc;
        background-color: #f9f9f9;
        box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
    }

    input[type="search"] {
        width: 100%;
        height: 50px;
        padding: 10px;
        font-size: 14px;
        border: 1px solid #ccc;
        border-radius: 10px;
        outline: none;
    }

    .Hero__bg__container__box2__Search__Btn {
        background-color: #8CB9C5;
        border: none;
        color: #2C3E50;
        padding: 1rem 2em;
        text-align: center;
        cursor: pointer;
        border-radius: 10px;
        transition: background-color 0.3s;
        width: 100%;
    }

    .Hero__bg__container__box2__Search__Btn:hover {
        background-color: #59808b;
    }
}


@media (width: 768px) {
    .Hero__bg__Tittle {
        max-width: 400px;
        font-size: 1.5rem;
        margin-top: -90px;
    }

    .Hero__bg__container {
        display: flex;
        flex-direction: column;
        text-align: center;
        align-items: center;
    }

    .Hero__bg__container__box1 {
        width: 90%;
        height: 70px;
        margin-top: 50px;
    }

    .Hero__bg__container__box2 {
        height: 200px;
        border-bottom-left-radius: 15px;
        border-bottom-right-radius: 15px;
        flex-direction: column;
        align-items: center;
        justify-content: space-around;
    }

    .Hero__bg__container__box2__label,
    .Hero__bg__container__box2__item1,
    .Hero__bg__container__box2__item2 {
        width: 90%;
    }

    .Hero__bg__container__box2__label select {
        width: 100%;
        height: 50px;
        padding: 8px;
        border: 1px solid #ccc;
        border-radius: 8px;
        font-size: 16px;
        cursor: pointer;
        background-color: #f9f9f9;
        box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
    }

    input[type="search"] {
        width: 100%;
        height: 50px;
        padding: 10px;
        font-size: 16px;
        border: 1px solid #ccc;
        border-radius: 10px;
        outline: none;
    }

    .Hero__bg__container__box2__Search__Btn {
        background-color: #8CB9C5;
        border: none;
        color: #2C3E50;
        padding: 1.2rem 2em;
        text-align: center;
        cursor: pointer;
        border-radius: 10px;
        transition: background-color 0.3s;
    }
}

@media (max-width:1280px) {
    .Hero__bg__Tittle {
        max-width: 400px;
        font-size: 1.5rem;
        margin-top: -90px;
    }

    .Hero__bg__container {
        display: flex;
        flex-direction: column;
        text-align: center;
        align-items: center;
    }

    .Hero__bg__container__box1 {
        width: 90%;
        height: 70px;
        margin-top: 50px;
    }

    .Hero__bg__container__box2 {
        height: 200px;
        border-top-right-radius: 0;
        border-bottom-left-radius: 15px;
        border-bottom-right-radius: 15px;
        flex-direction: column;
        align-items: center;
        justify-content: space-around;
    }

    .Hero__bg__container__box2__label,
    .Hero__bg__container__box2__item1,
    .Hero__bg__container__box2__item2 {
        width: 90%;
    }

    .Hero__bg__container__box2__label select {
        width: 100%;
        height: 50px;
        padding: 8px;
        border: 1px solid #ccc;
        border-radius: 8px;
        font-size: 16px;
        cursor: pointer;
        background-color: #f9f9f9;
        box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
    }

    input[type="search"] {
        width: 100%;
        height: 50px;
        padding: 10px;
        font-size: 16px;
        border: 1px solid #ccc;
        border-radius: 10px;
        outline: none;
    }

    .Hero__bg__container__box2__Search__Btn {
        background-color: #8CB9C5;
        border: none;
        color: #2C3E50;
        padding: 1.2rem 2em;
        text-align: center;
        cursor: pointer;
        border-radius: 10px;
        transition: background-color 0.3s;
    }
}
</style>