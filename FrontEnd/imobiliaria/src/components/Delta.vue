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
                <p class="Delta__container__box__tittle">Somos a Sweet Home!</p>
                <p class="Delta__container__box__text">39 anos no mercado e varios imóveis oferecidos nos apoiam
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
    width: 100%;
    margin-top: 30px;
}

.Delta__container__box {
    display: flex;
    flex-direction: column;
    align-items: center;
    width: 23%;
    min-width: 250px;
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
}

.Delta__container__box__img img {
    width: 100%;
    height: 100%;
    object-fit: cover;
    border-radius: 50%;
}

.Delta__container__box__tittle {
    font-weight: 600;
    font-size: 16px;
    color: #2C3E50;
    margin-top: 20px;
    white-space: nowrap;
    overflow: hidden;
    text-overflow: ellipsis;
    width: 100%;
}

.Delta__container__box__text {
    font-weight: 500;
    font-size: 13px;
    padding-top: 2em;
    color: #2C3E50;
    width: 100%;
    word-wrap: break-word;
}

.Delta__container__tittle {
    font-weight: 600;
    font-size: 24px;
    text-align: center;
    margin-bottom: 20px;
    color: #2C3E50;
}

@media (max-width: 1024px) {
    .Delta__container__box {
        width: 47%;
    }
}

@media (max-width: 768px) {
    .Delta__container__box {
        width: 70%;
    }

    .Delta__container__box__img {
        width: 40px;
        height: 40px;
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
    }

    .Delta__container__box__tittle {
        font-size: 16px;
    }

    .Delta__container__box__text {
        font-size: 14px;
    }

    .Delta__container__tittle {
        font-size: 20px;
    }
}
</style>
