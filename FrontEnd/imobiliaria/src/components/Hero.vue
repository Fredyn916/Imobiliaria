<template>
    <div class="Hero__bg__container">
        <div class="Hero__bg__Tittle">
            Você muda, sua vida muda
        </div>

        <div class="Hero__bg__container__box1">
            <button class="Hero__bg__container__box1__btn">Alugar</button>
            <button class="Hero__bg__container__box1__btn">Comprar</button>
            <button class="Hero__bg__container__box1__btn">Imóvel Novo</button>
        </div>

        <div class="Hero__bg__container__box2">
            <div class="Hero__bg__container__box2__label">
                <select id="opcoes" name="opcoes">
                    <option disabled value="">Casa</option>
                    <option value="opcao1">Casa (Todos)</option>
                    <option value="opcao2">Casa em condomínio</option>
                    <option disabled value="opcao3">Apartamento</option>
                    <option value="opcao4">Apartamento (Todos)</option>
                    <option value="opcao5">Cobertura</option>
                    <option value="opcao6">Flat</option>
                    <option value="opcao7">Garden</option>
                    <option disabled value="opcao8">Lote</option>
                    <option value="opcao9">Lote (Todos)</option>
                    <option value="opcao10">Lote em condomínio</option>
                    <option disabled value="opcao11">Comercial</option>
                    <option value="opcao12">Comercial (Todos)</option>
                    <option value="opcao13">Sala-Andar</option>
                    <option value="opcao14">Loja</option>
                    <option value="opcao15">Galpão</option>
                    <option value="opcao16">Vaga de Garagem</option>
                    <option value="opcao17">Prédio</option>
                    <option disabled value="opcao18">Rural</option>
                    <option value="opcao19">Rural (Todos)</option>
                    <option disabled value="opcao20">Terreno/Lote</option>
                    <option value="opcao21">Chácara</option>
                    <option value="opcao22">Fazenda</option>
                </select>
            </div>

            <div class="Hero__bg__container__box2__item1">
                <input type="search" id="pesquisa" name="pesquisa"
                    placeholder="Digite cidades, bairros ou características para pesquisar...">
            </div>

            <div class="Hero__bg__container__box2__item2">
                <button class="Hero__bg__container__box2__Search__Btn">Buscar</button>
            </div>
        </div>
    </div>
</template>

<script>
export default {
    name: 'Hero',
    mounted() {
        const buttons = document.querySelectorAll('.Hero__bg__container__box1__btn');

        buttons.forEach(button => {
            button.addEventListener('click', () => {
                buttons.forEach(btn => btn.classList.remove('active'));
                button.classList.add('active');
            });
        });
    }
}
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
}

.Hero__bg__Tittle {
    max-width: 900px;
    font-size: 2.5rem;
    font-weight: 600;
    margin-top: -30px;
    color: white;
}

.Hero__bg__container__box1 {
    background-color: #FFF;
    width: 400px;
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
    color: black;
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
    border-top-right-radius: 15px;
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
    transition: border-color 0.3s;
}

input[type="search"]:focus {
    border-color: #007BFF;
    box-shadow: 0 0 5px rgba(0, 123, 255, 0.5);
}

.Hero__bg__container__box2__Search__Btn {
    background-color: #59808b;
    border: none;
    color: white;
    padding: 1.2rem 3em;
    text-align: center;
    cursor: pointer;
    border-radius: 10px;
    transition: background-color 0.3s;
    transition: .3s;
}

.Hero__bg__container__box2__Search__Btn:hover {
    background-color: #8CB9C5;
    color: #333;
    font-weight: bold;
}

@media (min-width: 0px) and (max-width: 768px) {
    .Hero__bg__Tittle {
        display: none;
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
        color: white;
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
        color: white;
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
        color: white;
        padding: 1.2rem 2em;
        text-align: center;
        cursor: pointer;
        border-radius: 10px;
        transition: background-color 0.3s;
    }
}
</style>