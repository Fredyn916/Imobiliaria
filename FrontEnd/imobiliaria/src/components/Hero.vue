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
                    <option value="" disabled selected>Selecione</option>
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
/* Container principal do componente Hero */
.Hero__bg__container {
    text-align: center;
    /* Alinha o conteúdo ao centro */
    width: 100%;
    /* Largura total */
    max-width: 1000px;
    /* Largura máxima de 1000px */
    margin: 0 auto;
    /* Centraliza horizontalmente */
    display: flex;
    /* Usa o modelo flexbox para layout */
    flex-direction: column;
    /* Organiza os itens verticalmente */
    justify-content: center;
    /* Alinha os itens no centro verticalmente */
    align-items: center;
    /* Alinha os itens no centro horizontalmente */
}

/* Estilo do título na seção Hero */
.Hero__bg__Tittle {
    max-width: 900px;
    /* Largura máxima do título */
    font-size: 2.5rem;
    /* Tamanho da fonte */
    font-weight: 600;
    /* Peso da fonte */
    margin-top: -30px;
    /* Margem superior negativa */
    color: #f3f7f8;
    /* Cor do texto */
}

/* Box 1 - Contém botões */
.Hero__bg__container__box1 {
    background-color: #FFF;
    /* Cor de fundo branca */
    width: 90%;
    /* Largura de 90% */
    height: 70px;
    /* Altura da caixa */
    border-top-left-radius: 15px;
    /* Bordas arredondadas no canto superior esquerdo */
    border-top-right-radius: 15px;
    /* Bordas arredondadas no canto superior direito */
    display: flex;
    /* Layout flexbox */
    align-items: center;
    /* Alinha os itens verticalmente */
    justify-content: space-around;
    /* Espaço uniforme entre os itens */
    margin-top: 50px;
    /* Margem superior */
}

/* Estilo dos botões dentro da box1 */
.Hero__bg__container__box1__btn {
    width: 28%;
    /* Largura de 28% */
    height: 50px;
    /* Altura de 50px */
    background-color: #FFF;
    /* Cor de fundo branca */
    color: #2C3E50;
    /* Cor do texto */
    font-size: 16px;
    /* Tamanho da fonte */
    font-weight: bold;
    /* Fonte em negrito */
    border: none;
    /* Sem borda */
    border-radius: 15px;
    /* Bordas arredondadas */
    cursor: pointer;
    /* Indica que é clicável */
    text-align: center;
    /* Alinha o texto ao centro */
    display: inline-block;
    /* Exibição em linha */
    position: relative;
    /* Posicionamento relativo para o pseudo-elemento */
    transition: background-color 0.3s ease, transform 0.2s ease;
    /* Transições suaves */
    line-height: 50px;
    /* Alinha o texto verticalmente */
}

/* Efeito ao passar o mouse no botão */
.Hero__bg__container__box1__btn:after {
    content: "";
    /* Cria um pseudo-elemento */
    position: absolute;
    /* Posiciona o pseudo-elemento */
    bottom: 5px;
    /* Alinhado à parte inferior */
    left: 0;
    /* Alinhado à esquerda */
    width: 0%;
    /* Inicialmente com largura zero */
    height: 2px;
    /* Altura do traço */
    background-color: black;
    /* Cor do traço */
    transition: width 0.3s ease;
    /* Transição suave para a largura */
}

/* Estilo do botão quando estiver ativo */
.Hero__bg__container__box1__btn.active {
    background-color: #f3f7f8;
    /* Cor de fundo ao ser ativado */
    transform: scale(1);
    /* Normaliza o tamanho */
}

/* Efeito do traço ao ativar o botão */
.Hero__bg__container__box1__btn.active:after {
    width: 100%;
    /* O traço ocupa toda a largura */
}

/* Box 2 - Contém campos e botões de entrada */
.Hero__bg__container__box2 {
    background-color: #FFF;
    /* Cor de fundo branca */
    width: 90%;
    /* Largura de 90% */
    height: 80px;
    /* Altura da caixa */
    border-bottom-left-radius: 15px;
    /* Bordas arredondadas no canto inferior esquerdo */
    border-bottom-right-radius: 15px;
    /* Bordas arredondadas no canto inferior direito */
    display: flex;
    /* Layout flexbox */
    justify-content: space-around;
    /* Espaço uniforme entre os itens */
}

/* Estilo do label dentro de box2 */
.Hero__bg__container__box2__label {
    width: 20%;
    /* Largura de 20% */
    display: flex;
    /* Flexbox para layout */
    align-items: center;
    /* Alinha verticalmente */
    justify-content: center;
    /* Alinha horizontalmente */
    font-size: 10px;
    /* Tamanho da fonte */
}

/* Estilo do primeiro item de box2 */
.Hero__bg__container__box2__item1 {
    width: 60%;
    /* Largura de 60% */
    display: flex;
    /* Flexbox para layout */
    align-items: center;
    /* Alinha verticalmente */
    justify-content: center;
    /* Alinha horizontalmente */
}

/* Estilo do segundo item de box2 */
.Hero__bg__container__box2__item2 {
    width: 15%;
    /* Largura de 15% */
    display: flex;
    /* Flexbox para layout */
    align-items: center;
    /* Alinha verticalmente */
    justify-content: center;
    /* Alinha horizontalmente */
}

/* Estilo do campo select */
.Hero__bg__container__box2__label select {
    width: 100%;
    /* Largura total */
    height: 50px;
    /* Altura do campo */
    padding: 8px;
    /* Espaçamento interno */
    border: 1px solid #4D5656;
    /* Borda fina */
    color: #2C3E50;
    /* Cor do texto */
    border-radius: 8px;
    /* Bordas arredondadas */
    font-size: 16px;
    /* Tamanho da fonte */
    cursor: pointer;
    /* Cursor de mão ao passar por cima */
    background-color: #f9f9f9;
    /* Cor de fundo clara */
    box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
    /* Sombra leve */
}

/* Estilo do campo de pesquisa */
input[type="search"] {
    width: 100%;
    /* Largura total */
    height: 50px;
    /* Altura do campo */
    padding: 10px;
    /* Espaçamento interno */
    font-size: 16px;
    /* Tamanho da fonte */
    border: 1px solid #ccc;
    /* Borda clara */
    border-radius: 10px;
    /* Bordas arredondadas */
    outline: none;
    /* Remove o contorno padrão */
    transition: border-color 0.3s;
    /* Transição suave na cor da borda */
}

/* Efeito no campo de pesquisa quando em foco */
input[type="search"]:focus {
    border-color: #007BFF;
    /* Altera a cor da borda */
    box-shadow: 0 0 5px rgba(0, 123, 255, 0.5);
    /* Sombra azul ao focar */
}

/* Estilo do botão de pesquisa */
.Hero__bg__container__box2__Search__Btn {
    background-color: rgb(0, 43, 82);
    /* Cor de fundo */
    border: none;
    /* Sem borda */
    color: #FFF;
    /* Cor do texto */
    padding: 1.2rem 3em;
    /* Espaçamento interno */
    text-align: center;
    /* Alinha o texto ao centro */
    cursor: pointer;
    /* Indica que é clicável */
    border-radius: 10px;
    /* Bordas arredondadas */
    transition: background-color 0.3s;
    /* Transição suave */
    transition: .3s;
    /* Transição geral */
}

/* Efeito ao passar o mouse sobre o botão de pesquisa */
.Hero__bg__container__box2__Search__Btn:hover {
    background-color: #1A5276;
    /* Altera a cor de fundo */
    transform: scale(1.05);
    /* Aumenta ligeiramente o tamanho */
    font-weight: bold;
    /* Deixa o texto em negrito */
}

/* Media Query para telas pequenas (até 768px) */
@media (min-width: 0px) and (max-width: 768px) {
    .Hero__bg__Tittle {
        display: block;
        /* Exibe o título como bloco */
        padding-top: 80px;
        /* Adiciona margem superior */
    }

    .Hero__bg__container {
        display: flex;
        /* Flexbox para o layout */
        flex-direction: column;
        /* Organiza verticalmente */
        text-align: center;
        /* Alinha o texto ao centro */
        align-items: center;
        /* Alinha os itens ao centro */
        width: 100%;
        /* Largura total */
        padding: 0 10px;
        /* Padding lateral */
    }

    .Hero__bg__container__box1 {
        width: 100%;
        /* Largura total */
        height: auto;
        /* Ajusta altura automaticamente */
        margin-top: 20px;
        /* Margem superior */
        display: flex;
        /* Flexbox para o layout */
        justify-content: space-between;
        /* Espaço entre os itens */
        flex-wrap: wrap;
        /* Permite que os itens se ajustem */
        padding: 0 10px;
        /* Padding lateral */
    }

    .Hero__bg__container__box1__btn {
        width: 33%;
        /* Largura de 33% */
        height: 50px;
        /* Altura do botão */
        margin-bottom: 10px;
        /* Margem inferior */
        font-size: 14px;
        /* Tamanho da fonte */
        border-radius: 10px;
        /* Bordas arredondadas */
        text-align: center;
        /* Alinha o texto ao centro */
        line-height: 50px;
        /* Alinha verticalmente */
    }

    .Hero__bg__container__box2 {
        width: 90%;
        /* Largura de 90% */
        height: auto;
        /* Ajusta altura automaticamente */
        border-bottom-left-radius: 15px;
        /* Bordas arredondadas */
        border-bottom-right-radius: 15px;
        /* Bordas arredondadas */
        padding: 15px;
        /* Padding interno */
        display: flex;
        /* Flexbox para layout */
        flex-direction: column;
        /* Organiza verticalmente */
        align-items: center;
        /* Alinha os itens ao centro */
        justify-content: space-between;
        /* Espaço entre os itens */
    }

    .Hero__bg__container__box2__label,
    .Hero__bg__container__box2__item1,
    .Hero__bg__container__box2__item2 {
        width: 100%;
        /* Largura total */
        margin-bottom: 10px;
        /* Margem inferior */
    }

    .Hero__bg__container__box2__label select {
        width: 100%;
        /* Largura total */
        height: 50px;
        /* Altura do campo */
        padding: 8px;
        /* Espaçamento interno */
        font-size: 14px;
        /* Tamanho da fonte */
        border-radius: 8px;
        /* Bordas arredondadas */
        border: 1px solid #ccc;
        /* Borda clara */
        background-color: #f9f9f9;
        /* Cor de fundo clara */
        box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
        /* Sombra leve */
    }

    input[type="search"] {
        width: 100%;
        /* Largura total */
        height: 50px;
        /* Altura do campo */
        padding: 10px;
        /* Espaçamento interno */
        font-size: 14px;
        /* Tamanho da fonte */
        border: 1px solid #ccc;
        /* Borda clara */
        border-radius: 10px;
        /* Bordas arredondadas */
        outline: none;
        /* Remove o contorno */
    }

    .Hero__bg__container__box2__Search__Btn {
        background-color: #8CB9C5;
        /* Cor de fundo */
        border: none;
        /* Sem borda */
        color: #2C3E50;
        /* Cor do texto */
        padding: 1rem 2em;
        /* Espaçamento interno */
        text-align: center;
        /* Alinha o texto ao centro */
        cursor: pointer;
        /* Indica que é clicável */
        border-radius: 10px;
        /* Bordas arredondadas */
        transition: background-color 0.3s;
        /* Transição suave */
        width: 100%;
        /* Largura total */
    }

    .Hero__bg__container__box2__Search__Btn:hover {
        background-color: #59808b;
        /* Altera a cor ao passar o mouse */
    }
}

/* Media Query para telas com largura de 768px */
@media (width: 768px) {
    .Hero__bg__Tittle {
        max-width: 400px;
        /* Largura máxima reduzida */
        font-size: 1.5rem;
        /* Tamanho da fonte */
        margin-top: -90px;
        /* Margem superior negativa */
    }

    .Hero__bg__container {
        display: flex;
        /* Flexbox para layout */
        flex-direction: column;
        /* Organiza verticalmente */
        text-align: center;
        /* Alinha o texto ao centro */
        align-items: center;
        /* Alinha os itens ao centro */
    }

    .Hero__bg__container__box1 {
        width: 90%;
        /* Largura de 90% */
        height: 70px;
        /* Altura do box */
        margin-top: 50px;
        /* Margem superior */
    }

    .Hero__bg__container__box2 {
        height: 200px;
        /* Altura do box */
        border-bottom-left-radius: 15px;
        /* Bordas arredondadas */
        border-bottom-right-radius: 15px;
        /* Bordas arredondadas */
        flex-direction: column;
        /* Organiza verticalmente */
        align-items: center;
        /* Alinha os itens ao centro */
        justify-content: space-around;
        /* Espaço uniforme */
    }

    .Hero__bg__container__box2__label,
    .Hero__bg__container__box2__item1,
    .Hero__bg__container__box2__item2 {
        width: 90%;
        /* Largura de 90% */
    }

    .Hero__bg__container__box2__label select {
        width: 100%;
        /* Largura total */
        height: 50px;
        /* Altura do campo */
        padding: 8px;
        /* Espaçamento interno */
        border: 1px solid #ccc;
        /* Borda clara */
        border-radius: 8px;
        /* Bordas arredondadas */
        font-size: 16px;
        /* Tamanho da fonte */
        cursor: pointer;
        /* Cursor de mão */
        background-color: #f9f9f9;
        /* Cor de fundo clara */
        box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
        /* Sombra leve */
    }

    input[type="search"] {
        width: 100%;
        /* Largura total */
        height: 50px;
        /* Altura do campo */
        padding: 10px;
        /* Espaçamento interno */
        font-size: 16px;
        /* Tamanho da fonte */
        border: 1px solid #ccc;
        /* Borda clara */
        border-radius: 10px;
        /* Bordas arredondadas */
        outline: none;
        /* Remove o contorno */
    }

    .Hero__bg__container__box2__Search__Btn {
        background-color: #8CB9C5;
        /* Cor de fundo */
        border: none;
        /* Sem borda */
        color: #2C3E50;
        /* Cor do texto */
        padding: 1.2rem 2em;
        /* Espaçamento interno */
        text-align: center;
        /* Alinha o texto ao centro */
        cursor: pointer;
        /* Indica que é clicável */
        border-radius: 10px;
        /* Bordas arredondadas */
        transition: background-color 0.3s;
        /* Transição suave */
    }
}

/* Media Query para telas com largura até 1280px */
@media (max-width:1280px) {
    .Hero__bg__Tittle {
        max-width: 400px;
        /* Largura máxima reduzida */
        font-size: 1.5rem;
        /* Tamanho da fonte */
        margin-top: -90px;
        /* Margem superior negativa */
    }

    .Hero__bg__container {
        display: flex;
        /* Flexbox para layout */
        flex-direction: column;
        /* Organiza verticalmente */
        text-align: center;
        /* Alinha o texto ao centro */
        align-items: center;
        /* Alinha os itens ao centro */
    }

    .Hero__bg__container__box1 {
        width: 90%;
        /* Largura de 90% */
        height: 70px;
        /* Altura do box */
        margin-top: 50px;
        /* Margem superior */
    }

    .Hero__bg__container__box2 {
        height: 200px;
        /* Altura do box */
        border-top-right-radius: 0;
        /* Remove a borda superior direita */
        border-bottom-left-radius: 15px;
        /* Bordas arredondadas */
        border-bottom-right-radius: 15px;
        /* Bordas arredondadas */
        flex-direction: column;
        /* Organiza verticalmente */
        align-items: center;
        /* Alinha os itens ao centro */
        justify-content: space-around;
        /* Espaço uniforme */
    }

    .Hero__bg__container__box2__label,
    .Hero__bg__container__box2__item1,
    .Hero__bg__container__box2__item2 {
        width: 90%;
        /* Largura de 90% */
    }

    .Hero__bg__container__box2__label select {
        width: 100%;
        /* Largura total */
        height: 50px;
        /* Altura do campo */
        padding: 8px;
        /* Espaçamento interno */
        border: 1px solid #ccc;
        /* Borda clara */
        border-radius: 8px;
        /* Bordas arredondadas */
        font-size: 16px;
        /* Tamanho da fonte */
        cursor: pointer;
        /* Cursor de mão */
        background-color: #f9f9f9;
        /* Cor de fundo clara */
        box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
        /* Sombra leve */
    }

    input[type="search"] {
        width: 100%;
        /* Largura total */
        height: 50px;
        /* Altura do campo */
        padding: 10px;
        /* Espaçamento interno */
        font-size: 16px;
        /* Tamanho da fonte */
        border: 1px solid #ccc;
        /* Borda clara */
        border-radius: 10px;
        /* Bordas arredondadas */
        outline: none;
        /* Remove o contorno */
    }

    .Hero__bg__container__box2__Search__Btn {
        background-color: #8CB9C5;
        /* Cor de fundo */
        border: none;
        /* Sem borda */
        color: #2C3E50;
        /* Cor do texto */
        padding: 1.2rem 2em;
        /* Espaçamento interno */
        text-align: center;
        /* Alinha o texto ao centro */
        cursor: pointer;
        /* Indica que é clicável */
        border-radius: 10px;
        /* Bordas arredondadas */
        transition: background-color 0.3s;
        /* Transição suave */
    }
}
</style>