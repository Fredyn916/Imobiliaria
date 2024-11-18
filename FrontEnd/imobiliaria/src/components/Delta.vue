<template>
    <section class="Delta__internal__container">
        <p class="Delta__container__tittle">Acompanhamos você a cada passo</p>
        <div class="Delta__container">
            <div class="Delta__container__box">
                <div class="Delta__container__box__img">
                    <img src="@/Images/1.png" alt="Busca clara e rápida">
                </div>
                <p class="Delta__container__box__tittle">Busca clara e rápida</p>
                <p class="Delta__container__box__text">Pensamos em nossos filtros e mapas para simplificar sua
                    experiência em nosso portal.</p>
            </div>
            <div class="Delta__container__box">
                <div class="Delta__container__box__img">
                    <img src="@/Images/2.png" alt="Você tem sua própria seção">
                </div>
                <p class="Delta__container__box__tittle">Você tem sua própria seção</p>
                <p class="Delta__container__box__text">Acesse com facilidade e segurança os avisos de contato,
                    favoritos, notas que você criou e muito mais.</p>
            </div>
            <div class="Delta__container__box">
                <div class="Delta__container__box__img">
                    <img src="@/Images/3.png" alt="Variedade de anunciantes">
                </div>
                <p class="Delta__container__box__tittle">Variedade de anunciantes</p>
                <p class="Delta__container__box__text">Corretores de imóveis e proprietários diretos de todo o país
                    oferecem as melhores opções de imóveis para você.</p>
            </div>
            <div class="Delta__container__box">
                <div class="Delta__container__box__img">
                    <img src="@/Images/4.png" alt="Somos o Casa Mineira!">
                </div>
                <p class="Delta__container__box__tittle">Somos o Casa Mineira!</p>
                <p class="Delta__container__box__text">39 anos no mercado e um milhão de imóveis oferecidos nos apoiam
                    na busca pela sua casa.</p>
            </div>
        </div>
    </section>
</template>

<script>
export default {
    name: 'Delta',
}
</script>

<style scoped>
.Delta__internal__container {
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
    padding: 20px;
    width: 100%;
    box-sizing: border-box;
}

.Delta__container {
    display: flex;
    flex-wrap: wrap;
    justify-content: center;
    gap: 30px;
    /* Usando gap para separar os itens de maneira mais controlada */
    width: 100%;
    margin-top: 30px;
}

.Delta__container__box {
    display: flex;
    flex-direction: column;
    align-items: center;
    width: 23%;
    min-width: 250px;
    /* Garante que as caixas não fiquem muito pequenas em telas grandes */
    height: auto;
    background: #fff;
    border-radius: 12px;
    text-align: center;
    box-shadow: 0 4px 10px rgba(0, 0, 0, 0.1);
    padding-top: 50px;
    padding: 20px;
    position: relative;
}

.Delta__container__box__img {
    position: absolute;
    top: -30px;
    width: 60px;
    height: 60px;
    background-size: cover;
    background-position: center;
    border-radius: 50%;
    border: 4px solid white;
}

.Delta__container__box__img img {
    width: 100%;
    height: 100%;
    object-fit: cover;
    border-radius: 50%;
}

.Delta__container__box__tittle {
    font-weight: 600;
    font-size: 18px;
    color: #000;
    margin-top: 20px;
}

.Delta__container__box__text {
    font-weight: 500;
    font-size: 13px;
    padding-top: 2em;
    color: #000;
    text-align: justify;
}

.Delta__container__tittle {
    font-weight: 600;
    font-size: 24px;
    text-align: center;
    margin-bottom: 20px;
}

@media (max-width: 1024px) {
    .Delta__container__box {
        width: 48%;
        /* 2 colunas no tablet */
    }
}

@media (max-width: 768px) {
    .Delta__container__box {
        width: 70%;
        /* 1.5 colunas no tablet pequeno */
    }

    .Delta__container__box__img {
        width: 80px;
        height: 80px;
        top: -25px;
    }

    .Delta__container__box__tittle {
        font-size: 18px;
    }

    .Delta__container__box__text {
        font-size: 12px;
    }

    .Delta__container__tittle {
        font-size: 18px;
    }
}

@media (max-width: 480px) {
    .Delta__container__box {
        width: 100%;
        /* Caixa ocupa toda a largura da tela no celular */
    }

    .Delta__container__box__tittle {
        font-size: 16px;
    }

    .Delta__container__box__text {
        font-size: 12px;
    }

    .Delta__container__tittle {
        font-size: 16px;
    }
}
</style>