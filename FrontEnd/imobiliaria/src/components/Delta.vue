<template>
    <section class="Delta__internal__container">
        <p class="Delta__container__tittle">Acompanhamos você a cada passo</p>
        <div class="Delta__container">
            <div class="Delta__container__box">
                <div class="Delta__container__box__img"><img
                        src="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAQ4AAACUCAMAAABV5TcGAAAAA1BMVEUAAACnej3aAAAAPklEQVR4nO3BMQEAAADCoPVPbQwfoAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAgIcBnKwAAXyxvCsAAAAASUVORK5CYII="
                        alt="Busca clara e rápida"></div>
                <p class="Delta__container__box__tittle">Busca clara e rápida</p>
                <p class="Delta__container__box__text">Pensamos em nossos filtros e mapas para simplificar sua
                    experiência
                    em nosso portal.</p>
            </div>
            <div class="Delta__container__box">
                <div class="Delta__container__box__img"><img
                        src="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAQ4AAACUCAMAAABV5TcGAAAAA1BMVEUAAACnej3aAAAAPklEQVR4nO3BMQEAAADCoPVPbQwfoAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAgIcBnKwAAXyxvCsAAAAASUVORK5CYII="
                        alt="Você tem sua própria seção"></div>
                <p class="Delta__container__box__tittle">Você tem sua própria seção</p>
                <p class="Delta__container__box__text">Acesse com facilidade e segurança os avisos de contato,
                    favoritos,
                    notas que você criou e muito mais.</p>
            </div>
            <div class="Delta__container__box">
                <div class="Delta__container__box__img"><img
                        src="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAQ4AAACUCAMAAABV5TcGAAAAA1BMVEUAAACnej3aAAAAPklEQVR4nO3BMQEAAADCoPVPbQwfoAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAgIcBnKwAAXyxvCsAAAAASUVORK5CYII="
                        alt="Variedade de anunciantes"></div>
                <p class="Delta__container__box__tittle">Variedade de anunciantes</p>
                <p class="Delta__container__box__text">Corretores de imóveis e proprietários diretos de todo o país
                    oferecem
                    as melhores opções de imóveis para você.</p>
            </div>
            <div class="Delta__container__box">
                <div class="Delta__container__box__img"><img
                        src="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAQ4AAACUCAMAAABV5TcGAAAAA1BMVEUAAACnej3aAAAAPklEQVR4nO3BMQEAAADCoPVPbQwfoAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAgIcBnKwAAXyxvCsAAAAASUVORK5CYII="
                        alt="Somos o Casa Mineira!"></div>
                <p class="Delta__container__box__tittle">Somos o Casa Mineira!</p>
                <p class="Delta__container__box__text">39 anos no mercado e um milhão de imóveis oferecidos nos apoiam
                    na
                    busca pela sua casa.</p>
            </div>
        </div>
    </section>
</template>

<script>
export default {
    name: 'Delta'
}
</script>

<style scoped>
.Delta__internal__container {
    display: flex;
    flex-direction: column;
    align-items: center;
    height: 100%;
    padding: 20px;
}

.Delta__container {
    display: flex;
    flex-wrap: wrap;
    justify-content: space-between;
    gap: 20px;
    padding: 0 20px;
    width: 100%;
    margin-top: 30px;
}

.Delta__container__box {
    display: flex;
    flex-direction: column;
    align-items: center;
    width: 22%;
    min-width: 240px;
    height: auto;
    background: rgb(255, 255, 255);
    border-radius: 12px;
    text-align: center;
    box-shadow: 0 4px 10px rgba(0, 0, 0, 0.1);
    padding-top: 50px;
    position: relative;
}

.Delta__container__box__img {
    position: absolute;
    top: -30px;
    width: 100px;
    height: 100px;
    background-size: cover;
    background-position: center;
    border-radius: 50%;
    border: 4px solid white;
    transform: translateY(-20%);
}

.Delta__container__box__img img {
    width: 100%;
    height: 100%;
    object-fit: cover;
    border-radius: 50%;
}

.Delta__container__box__tittle {
    font-weight: 600;
    font-size: 20px;
    margin-top: 50px;
    color: #000;
}

.Delta__container__box__text {
    font-weight: 500;
    font-size: 14px;
    padding-top: 10px;
    color: #000;
}

.Delta__container__tittle {
    font-weight: 600;
    font-size: 24px;
    text-align: center;
    margin-bottom: 20px;
}

@media (min-width: 0px) and (max-width: 480px) {
    .Delta__container__box__tittle {
        font-size: 14px;
    }

    .Delta__container__box__text {
        font-size: 8px;
    }

    .Delta__container__tittle {
        font-size: 14px;
    }
}

@media (min-width: 481px) and (max-width: 768px) {
    .Delta__container {
        display: flex;
        flex-wrap: wrap;
        justify-content: center;
        gap: 20px;
        padding: 0 20px;
        width: 100%;
        margin-top: 30px;
    }
}


@media (max-width: 1024px) {
    .Delta__container__box {
        width: 48%;
    }
}

@media (max-width: 768px) {
    .Delta__container__box {
        width: 70%;
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
}
</style>
