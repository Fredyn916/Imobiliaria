<template>
    <!-- Seção principal do componente Delta -->
    <section class="Delta__internal__container">
        <!-- Título da seção -->
        <p class="Delta__container__tittle">Acompanhamos você a cada passo</p>

        <!-- Container com as caixas de informações -->
        <div class="Delta__container">
            <!-- Primeira caixa -->
            <div class="Delta__container__box">
                <div class="Delta__container__box__img">
                    <!-- Imagem representativa -->
                    <img src="@/Images/1.png" alt="Busca clara e rápida">
                </div>
                <!-- Título da caixa -->
                <p class="Delta__container__box__tittle">Busca clara e rápida</p>
                <!-- Texto explicativo da caixa -->
                <p class="Delta__container__box__text">Pensamos em nossos filtros e mapas para simplificar sua
                    experiência em nosso portal.</p>
            </div>

            <!-- Segunda caixa -->
            <div class="Delta__container__box">
                <div class="Delta__container__box__img">
                    <!-- Imagem representativa -->
                    <img src="@/Images/2.png" alt="Você tem sua própria seção">
                </div>
                <p class="Delta__container__box__tittle">Você tem sua própria seção</p>
                <p class="Delta__container__box__text">Acesse com facilidade e segurança os avisos de contato,
                    favoritos, notas que você criou e muito mais.</p>
            </div>

            <!-- Terceira caixa -->
            <div class="Delta__container__box">
                <div class="Delta__container__box__img">
                    <img src="@/Images/3.png" alt="Variedade de anunciantes">
                </div>
                <p class="Delta__container__box__tittle">Variedade de anunciantes</p>
                <p class="Delta__container__box__text">Corretores de imóveis e proprietários diretos de todo o país
                    oferecem as melhores opções de imóveis para você.</p>
            </div>

            <!-- Quarta caixa -->
            <div class="Delta__container__box">
                <div class="Delta__container__box__img">
                    <img src="@/Images/4.png" alt="Somos o Casa Mineira!">
                </div>
                <p class="Delta__container__box__tittle">Somos a Sweet Home!</p>
                <p class="Delta__container__box__text">39 anos no mercado e vários imóveis oferecidos nos apoiam
                    na busca pela sua casa.</p>
            </div>
        </div>
    </section>
</template>

<script>
export default {
    // Nome do componente para identificação
    name: 'Delta',
}
</script>

<style scoped>
/* Estilo do container principal */
.Delta__internal__container {
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
    padding: 20px;
    width: 100%;
    box-sizing: border-box;
}

/* Estilo do container que agrupa as caixas */
.Delta__container {
    display: flex;
    flex-wrap: wrap;
    justify-content: center;
    gap: 30px;
    width: 100%;
    margin-top: 30px;
}

/* Estilo das caixas */
.Delta__container__box {
    display: flex;
    flex-direction: column;
    align-items: center;
    width: 23%;
    min-width: 250px;
    background: #fff;
    border-radius: 12px;
    text-align: center;
    box-shadow: 0 4px 10px rgba(0, 0, 0, 0.1);
    padding: 20px;
    position: relative;
}

/* Estilo das imagens dentro das caixas */
.Delta__container__box__img {
    position: absolute;
    top: -30px;
    width: 60px;
    height: 60px;
    background-size: cover;
    border-radius: 50%;
}

.Delta__container__box__img img {
    width: 100%;
    height: 100%;
    object-fit: cover;
    border-radius: 50%;
}

/* Estilo do título de cada caixa */
.Delta__container__box__tittle {
    font-weight: 600;
    font-size: 16px;
    color: #2C3E50;
    margin-top: 20px;
    text-overflow: ellipsis;
    width: 100%;
}

/* Estilo do texto explicativo de cada caixa */
.Delta__container__box__text {
    font-weight: 500;
    font-size: 13px;
    color: #2C3E50;
    margin-top: 20px;
}

/* Estilo do título geral da seção */
.Delta__container__tittle {
    font-weight: 600;
    font-size: 24px;
    text-align: center;
    margin-bottom: 20px;
    color: #2C3E50;
}

/* Estilos responsivos para dispositivos menores */
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
}

@media (max-width: 480px) {
    .Delta__container__box {
        width: 100%;
    }

    .Delta__container__tittle {
        font-size: 20px;
    }
}
</style>