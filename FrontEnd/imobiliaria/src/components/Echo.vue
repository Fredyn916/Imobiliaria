<template>
    <div class="Echo__Container">
        <div class="Echo__Box">

            <div class="Echo__Box__left">
                <h1 class="Echo__box__left__tittle">Você conhece nossas opções de imóveis novos?</h1>
                <p class="Echo__box__left__text">Você pode vê-los de acordo com o estágio da obra que melhor se adequa à
                    sua
                    pesquisa.</p>
                <button class="Echo__box__left__btn">Mais Empreendimentos em obras</button>
            </div>
            <div class="Echo__Box__rigth"></div>
        </div>
    </div>
</template>

<script>
export default {
    name: 'Echo'
}
</script>

<style scoped>
.Echo__Container {
    width: 100%;
    display: flex;
    justify-content: center;
    align-items: center;
    padding: 20px;
}

.Echo__Box {
    width: 80%;
    height: 500px;
    background-color: #FFF;
    border: 5px solid #ededed;
    color: #333;
    padding: 20px;
    border-radius: 8px;
    font-size: 1.2em;
    text-align: center;
    display: flex;
}

.Echo__Box__left {
    flex: 1;
    max-width: 50%;
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
}

.Echo__box__left__text {
    font-size: 14px;
}

.Echo__box__left__btn {
    max-width: 60%;
    height: 15%;
    border: 1px solid #333;
    background-color: #FFF;
    border-radius: 10px;
    font-weight: bold;
    cursor: pointer;
}

.Echo__Box__rigth {
    flex: 1;
    border: 1px solid #333;
    max-width: 50%;
    height: 100%;
}

@media(max-width: 768px) {
    .Echo__Container {
        width: 100%;
        height: 100%;
        flex-direction: column;
    }

    .Echo__Box {
        flex-direction: column;
        border: none;
        width: 100%;
        height: 100%;
        padding: 0;
    }

    .Echo__Box__left {
        max-width: 100%;
        max-height: 30%;
        flex-direction: column;
        padding: 0;
    }

    .Echo__Box__rigth {
        max-width: 100%;
        max-height: 100%;
    }

    .Echo__box__left__tittle {
        font-weight: 600;
        max-width: 100%;
        font-size: 25px;
    }

    .Echo__box__left__btn {
        display: none;
    }
}
</style>
