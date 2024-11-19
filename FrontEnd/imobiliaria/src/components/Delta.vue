<template>

    <p class="Delta__container__tittle">Acompanhamos você a cada passo</p>
    <div class="Delta__container">
        <div class="Delta__container__box">
            <p class="Delta__container__box__tittle">Busca clara e rápida</p>
            <p class="Delta__container__box__text">Pensamos em nossos filtros e mapas para simplificar sua experiência
                em
                nosso portal.</p>
        </div>
        <div class="Delta__container__box">
            <p class="Delta__container__box__tittle">Você tem sua própria seção</p>
            <p class="Delta__container__box__text">Acesse com facilidade e segurança os avisos de contato, favoritos,
                notas que você criou e muito mais.</p>
        </div>
        <div class="Delta__container__box">
            <p class="Delta__container__box__tittle">Variedade de anunciantes</p>
            <p class="Delta__container__box__text">Corretores de imóveis e proprietários diretos de todo o país oferecem
                as melhores opções de imóveis para você.</p>
        </div>
        <div class="Delta__container__box">
            <p class="Delta__container__box__tittle">Somos o Casa Mineira!</p>
            <p class="Delta__container__box__text">39 anos no mercado e um milhão de imóveis oferecidos nos apoiam na
                busca pela sua casa.</p>
        </div>
    </div>
</template>

<script>
export default {
    name: 'Delta'
}
</script>

<style>
.Delta__container {
    display: flex;
    position: relative;
    -webkit-box-pack: justify;
    justify-content: space-between;
    top: 29px;
    max-width: 1600px;
}

.Delta__container__box {
    display: flex;
    flex-direction: column;
    -webkit-box-align: center;
    align-items: center;
    width: 350px;
    height: 133px;
    background: rgb(255, 255, 255);
    border-radius: 12px;
    text-align: center;
    margin-right: 40px;
    color: #000;
    padding-top: 10px;
}

.Delta__container__box__tittle {
    max-width: 400px;
    font-weight: 600;
    font-size: 20px;
    position: relative;
    padding-top: 20px;
}

.Delta__container__box__text {
    font-weight: 500;
    font-size: 12px;
    position: relative;
    padding-top: 10px;
}

.Delta__container__tittle {
    font-weight: 600;
    font-size: 20px;
    position: relative;
    top: -15px;
}


@media(width < 1280px) {}


/* Para dispositivos móveis (até 600px) */
@media (min-width: 200px) and (max-width: 600px) {
    .Delta__container {
        display: flex;
        flex-direction: column;
        align-items: center;
        gap: 20px;
    }

    .Delta__container__box__tittle {
        font-weight: 400;
        font-size: 16px;
        position: relative;
        top: 20px;
    }

    .Delta__container__box__text {
        font-weight: 300;
        font-size: 8px;
        position: relative;
        top: 20px;
    }

    .Delta__container__tittle {
        font-weight: 400;
        font-size: 16px;
        position: relative;
        top: -15px;
    }
}

/* Para tablets (de 601px a 900px) */
@media (min-width: 601px) and (max-width: 900px) {

    .Delta__container {
        display: flex;
        flex-direction: column;
        align-items: center;
        gap: 20px;
    }

    .Delta__container__box__tittle {
        font-weight: 400;
        font-size: 16px;
        position: relative;
        top: 20px;
    }

    .Delta__container__box__text {
        font-weight: 300;
        font-size: 8px;
        position: relative;
        top: 20px;
    }

    .Delta__container__tittle {
        font-weight: 400;
        font-size: 16px;
        position: relative;
        top: -15px;
    }
}

/* Para desktops menores (1025px a 1280px) */
@media (min-width: 1025px) and (max-width: 1280px) {}

@media (min-width: 1280px) and (max-width: 1600px) {
    .Delta__container {
        display: flex;
        position: relative;
        -webkit-box-pack: justify;
        justify-content: space-between;
        top: 29px;
        max-width: 1600px;
    }


    .Delta__container__box__tittle {
        font-weight: 600;
        font-size: 14px;
        position: relative;
        top: 20px;
    }

    .Delta__container__box__text {
        font-weight: 500;
        font-size: 9px;
        position: relative;
        top: 20px;
    }

    .Delta__container__tittle {
        font-weight: 600;
        font-size: 18px;
        position: relative;
        top: -15px;
    }
}

/* Para desktops grandes (acima de 1280px) */
@media (min-width: 1601px) {}
</style>