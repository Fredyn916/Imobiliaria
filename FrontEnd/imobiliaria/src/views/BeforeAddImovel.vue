<template>
    <div class="Banner">
        <div class="Banner__container">
            <div class="Banner__item">
                <div class="Banner__item__color">
                    <h1>
                        <span class="typing__text" :class="typingClass">{{ displayedText }}</span> seu imóvel
                    </h1>
                    <h2>de forma rápida e fácil</h2>
                    Publique gratuitamente no portal líder do mercado imobiliário.

                </div>
                <div class="btns__container">
                    <RouterLink to="Precificador">
                        <button class="Precifier__btn">Precifique meu Imóvel
                            <svg version="1.0" xmlns="http://www.w3.org/2000/svg" width="10px" height="10px"
                                viewBox="0 0 512.000000 512.000000" preserveAspectRatio="xMidYMid meet">
                                <g transform="translate(0.000000,512.000000) scale(0.100000,-0.100000)" fill="#000000"
                                    stroke="none">
                                    <path d="M1206 5106 c-46 -17 -99 -67 -121 -113 -24 -51 -21 -134 7 -185 16
                    -30 378 -366 1228 -1141 663 -604 1205 -1102 1205 -1107 0 -5 -542 -503 -1205
                    -1107 -850 -775 -1212 -1111 -1228 -1141 -28 -51 -31 -134 -7 -186 24 -50 86
                    -103 137 -116 48 -13 115 -7 156 14 15 8 614 549 1332 1203 1026 935 1309
                    1199 1324 1230 24 54 24 152 0 206 -14 31 -300 297 -1324 1229 -718 655 -1318
                    1197 -1334 1205 -41 21 -124 26 -170 9z" />
                                </g>
                            </svg>
                        </button>
                    </RouterLink>
                    <RouterLink to="AnunciarSeuImovel">
                        <button class="AddImovel__btn">Publique meu Imóvel
                            <svg version="1.0" xmlns="http://www.w3.org/2000/svg" width="10px" height="10px"
                                viewBox="0 0 512.000000 512.000000" preserveAspectRatio="xMidYMid meet">
                                <g transform="translate(0.000000,512.000000) scale(0.100000,-0.100000)" fill="#000000"
                                    stroke="none">
                                    <path d="M1206 5106 c-46 -17 -99 -67 -121 -113 -24 -51 -21 -134 7 -185 16
                    -30 378 -366 1228 -1141 663 -604 1205 -1102 1205 -1107 0 -5 -542 -503 -1205
                    -1107 -850 -775 -1212 -1111 -1228 -1141 -28 -51 -31 -134 -7 -186 24 -50 86
                    -103 137 -116 48 -13 115 -7 156 14 15 8 614 549 1332 1203 1026 935 1309
                    1199 1324 1230 24 54 24 152 0 206 -14 31 -300 297 -1324 1229 -718 655 -1318
                    1197 -1334 1205 -41 21 -124 26 -170 9z" />
                                </g>
                            </svg>
                        </button>

                    </RouterLink>
                </div>
            </div>
        </div>
    </div>

    <div class="Range">
        <div class="Range__container">
            <div class="Range__item">
                <img src="@/Images/icon__people.svg" alt="img" class="Ranger__Img">
                <div class="Ranger__item__container">

                    <h1> 4,7 milhões</h1>

                    <p class="Ranger__P">de pessoas entram por mês procurando um lar.</p>
                </div>
            </div>
            <div class="Range__item">
                <img src="@/Images/icon__chat.svg" alt="img" class="Ranger__Img">
                <div class="Ranger__item__container">
                    <h1> 28 mil</h1>

                    <p class="Ranger__P">consultas que recebem nossos avisos por mês.</p>
                </div>
            </div>
            <div class="Range__item">
                <img src="@/Images/icon__key.svg" alt="img" class="Ranger__Img">
                <div class="Ranger__item__container">
                    <h1> + 3 mil</h1>

                    <p class="Ranger__P">proprietários confiam em nós para publicar seus imóveis.</p>
                </div>
            </div>
        </div>
    </div>

    <div class="Animated">
        <h1>Publique seu imóvel gratuitamente e em passos simples</h1>
        <div class="container">
            <div class="animation__container">
                <div v-for="(step, index) in steps" :key="index" class="step">
                    <div class="circle" :class="{ active: currentStep >= index }">
                        <span class="number">{{ step.id }}</span>
                        <div class="border__animation" :class="{ 'loading__animation': currentStep === index }"></div>
                    </div>
                    <p class="step__text">{{ step.text }}</p>
                </div>
            </div>
            <div class="Animated__Image">
                <transition name="fade">
                    <div class="image__container" v-if="imageVisible">
                        <img :src="currentImage" alt="Step image" />
                    </div>
                </transition>
            </div>
        </div>
    </div>
</template>

<script>
export default {
    name: 'BeforeAddImovel',
    data() {
        return {
            words: ["Alugue ", "Venda "], // Lista de frases
            currentWordIndex: 0,
            displayedText: "",
            typingClass: "typing", // Classe inicial para a animação de digitação,
            steps: [
                { id: 1, text: 'Localize seu imóvel no mapa', image: '@/Images/1.png' },
                { id: 2, text: 'Diga-nos como é', image: '@/Images/1.png' },
                { id: 3, text: 'Envie fotos e vídeos', image: '@/Images/1.png' },
                { id: 4, text: 'Escolha um plano', image: '@/Images/1.png' }
            ],
            currentStep: 0,
            imageVisible: false
        };
    },
    created() {
        this.startTyping();
    },
    computed: {
        currentImage() {
            return this.steps[this.currentStep]?.image;
        }
    },
    mounted() {
        this.animateSteps();
    },
    methods: {
        startTyping() {
            let index = 0;
            const word = this.words[this.currentWordIndex];
            this.displayedText = "";
            this.typingClass = "typing"; // Inicia a animação de digitação

            // Função para simular a digitação
            const typeInterval = setInterval(() => {
                if (index < word.length) {
                    this.displayedText += word[index];
                    index++;
                } else {
                    clearInterval(typeInterval);
                    setTimeout(() => {
                        this.startErasing(); // Começa a apagar a palavra
                    }, 1500);
                }
            }, 200);
        },
        startErasing() {
            let index = this.displayedText.length;
            const eraseInterval = setInterval(() => {
                if (index > 0) {
                    this.displayedText = this.displayedText.substring(0, index - 1);
                    index--;
                } else {
                    clearInterval(eraseInterval);
                    this.currentWordIndex = (this.currentWordIndex + 1) % this.words.length; // Vai para a próxima palavra
                    setTimeout(() => {
                        this.startTyping(); // Inicia o processo de digitação novamente
                    }, 500);
                }
            }, 80);
        },
        animateSteps() {
            const interval = 2000; // Tempo por etapa em ms
            const totalSteps = this.steps.length;
            const stepInterval = setInterval(() => {
                if (this.currentStep < totalSteps) {
                    this.fillAndShowImage();
                } else {
                    clearInterval(stepInterval);
                }
            }, interval);
        },
        fillAndShowImage() {
            if (this.currentStep < this.steps.length) {
                this.imageVisible = false;
                setTimeout(() => {
                    this.currentStep++;
                    this.imageVisible = true;
                }, 500); // Duração da transição de preenchimento
            }
        }
    },
};
</script>

<style>
/* Estilos para o banner principal */
.Banner {
    width: 100%;
    /* Largura 100% do contêiner */
    height: 450px;
    /* Altura fixa de 450px */
    background: url('https://res.cloudinary.com/fredmarques/image/upload/v1734056495/BgPublicarImovel_kmcsgq.png') no-repeat center center;
    /* Imagem de fundo centralizada */
    background-size: cover;
    /* A imagem cobre todo o espaço disponível */
    display: flex;
    /* Usando flexbox para alinhamento */
    justify-content: center;
    /* Centraliza o conteúdo dentro do Banner */
}

/* Container do Banner */
.Banner__container {
    width: 100%;
    /* Largura de 100% */
    height: 450px;
    /* Altura fixa de 450px */
    display: flex;
    /* Flexbox para posicionar os itens */
}

/* Item do Banner */
.Banner__item {
    flex: 1;
    /* Cada item ocupa o mesmo espaço */
    height: 100%;
    /* Altura total */
    width: 50%;
    /* Largura de 50% */
    display: flex;
    /* Usando flexbox para posicionamento */
    text-align: left;
    /* Alinha o texto à esquerda */
    flex-direction: column;
    /* Alinha os itens verticalmente */
    justify-content: center;
    /* Centraliza o conteúdo */
    padding-inline: 3rem;
    /* Espaçamento lateral */
    gap: 20px;
    /* Espaçamento entre os itens */
}

/* Efeito de digitação */
.typing {
    border-right: 2px solid #000;
    /* Borda piscando no lado direito */
    animation: blink-caret 0.75s step-end infinite;
    /* Animação de piscamento */
}

/* Container de botões dentro do Banner */
.btns__container {
    display: flex;
    /* Usando flexbox para alinhamento */
    align-items: center;
    /* Alinha os itens verticalmente */
    gap: 10px;
    /* Espaçamento entre os botões */
}

/* Estilo do botão Precifier */
.Precifier__btn {
    padding: 0.90rem 2rem;
    /* Padding do botão */
    border: 3px solid white;
    /* Borda branca */
    border-radius: 8px;
    /* Bordas arredondadas */
    background-color: transparent;
    /* Fundo transparente */
    color: #FFF;
    /* Cor do texto */
    font-weight: 600;
    /* Peso da fonte */
    font-size: 18px;
    /* Tamanho da fonte */
    transition: .3s;
    /* Transição suave */
}

/* Efeito hover no botão Precifier */
.Precifier__btn:hover {
    transform: scale(1.04);
    /* Aumenta um pouco o tamanho ao passar o mouse */
    cursor: pointer;
    /* Cursor de ponteiro */
}

/* Estilo do botão AddImovel */
.AddImovel__btn {
    padding: 0.90rem 2rem;
    /* Padding do botão */
    background-color: rgb(0, 43, 82);
    /* Cor de fundo azul */
    border: none;
    /* Sem borda */
    border-radius: 8px;
    /* Bordas arredondadas */
    color: #FFF;
    /* Cor do texto */
    font-weight: 600;
    /* Peso da fonte */
    font-size: 18px;
    /* Tamanho da fonte */
    transition: .3s;
    /* Transição suave */
}

/* Efeito hover no botão AddImovel */
.AddImovel__btn:hover {
    background-color: #1A5276;
    /* Cor de fundo alterada ao passar o mouse */
    transform: scale(1.04);
    /* Aumenta o tamanho ao passar o mouse */
    cursor: pointer;
    /* Cursor de ponteiro */
}

/* Cor do texto dentro do item Banner */
.Banner__item__color {
    color: #FFF;
    /* Cor branca */
    font-weight: 600;
    /* Peso da fonte */
    font-size: 1rem;
    /* Tamanho da fonte */
}

/* Estilo do texto que simula digitação */
.typing__text {
    color: rgb(0, 43, 82);
    /* Cor do texto azul */
}

/* Estilos para o Range (faixa de valores) */
.Range {
    width: 100%;
    /* Largura de 100% */
    height: 200px;
    /* Altura de 200px */
    background-color: #ededed;
    /* Cor de fundo cinza claro */
}

/* Container do Range */
.Range__container {
    width: 100%;
    /* Largura de 100% */
    height: 100%;
    /* Altura de 100% */
    display: flex;
    /* Usando flexbox para alinhamento */
}

/* Item dentro do Range */
.Range__item {
    flex: 1;
    /* Cada item ocupa o mesmo espaço */
    height: 100%;
    /* Altura total */
    display: flex;
    /* Usando flexbox para alinhamento */
    align-items: center;
    /* Alinha os itens verticalmente */
    justify-content: center;
    /* Centraliza o conteúdo */
}

/* Container do item do Range */
.Range__item__container {
    display: flex;
    /* Usando flexbox para o layout */
    flex-direction: column;
    /* Organiza os itens em coluna */
}

/* Estilo do texto dentro do Range */
.Ranger__P {
    max-width: 250px;
    /* Largura máxima de 250px */
}

/* Estilos para animação */
.Animated {
    width: 100%;
    /* Largura total */
    height: 500px;
    /* Altura de 500px */
    display: flex;
    /* Usando flexbox para alinhamento */
    text-align: center;
    /* Alinha o texto ao centro */
    flex-direction: column;
    /* Organiza os itens em coluna */
    gap: 40px;
    /* Espaçamento entre os itens */
}

/* Container de animação interna */
.Internal__Animated {
    display: flex;
    /* Usando flexbox */
    justify-content: space-around;
    /* Distribui os itens igualmente */
}

/* Container da animação */
.animation__container {
    position: relative;
    /* Posição relativa para controle de layout */
    width: 50%;
    /* Largura de 50% */
    margin: auto;
    /* Centraliza o container */
    display: flex;
    /* Usando flexbox */
    flex-direction: column;
    /* Organiza os itens em coluna */
    justify-content: center;
    /* Centraliza o conteúdo */
    padding-left: 200px;
    /* Espaçamento à esquerda */
    flex: 1;
    /* Flexível, ocupa o espaço disponível */
}

/* Estilo da imagem de animação */
.Animated__Image {
    flex: 1;
    /* Flexível, ocupa o espaço disponível */
    width: 50%;
    /* Largura de 50% */
    height: 100%;
    /* Altura total */
    display: flex;
    /* Usando flexbox */
    justify-content: center;
    /* Centraliza a imagem */
    align-items: center;
    /* Alinha a imagem verticalmente */
}

/* Estilo do container geral */
.container {
    display: flex;
    /* Usando flexbox */
    align-items: center;
    /* Alinha os itens verticalmente */
    justify-content: center;
    /* Centraliza os itens */
}

/* Estilo para cada etapa */
.step {
    display: flex;
    /* Usando flexbox */
    align-items: center;
    /* Alinha os itens verticalmente */
    margin-bottom: 20px;
    /* Espaço abaixo de cada etapa */
}

/* Estilo do círculo indicador */
.circle {
    position: relative;
    /* Posição relativa para controle */
    width: 50px;
    /* Largura de 50px */
    height: 50px;
    /* Altura de 50px */
    border: 2px solid white;
    /* Borda branca */
    border-radius: 50%;
    /* Forma circular */
    display: flex;
    /* Usando flexbox */
    align-items: center;
    /* Alinha o conteúdo verticalmente */
    justify-content: center;
    /* Alinha o conteúdo horizontalmente */
    overflow: hidden;
    /* Garante que nada ultrapasse o círculo */
    margin-right: 10px;
    /* Espaço à direita */
}

/* Estilo para círculo ativo */
.circle.active {
    border-color: rgb(0, 43, 82);
    /* Cor azul quando ativo */
}

/* Estilo do número dentro do círculo */
.number {
    font-size: 16px;
    /* Tamanho da fonte */
    font-weight: bold;
    /* Peso da fonte */
    z-index: 2;
    /* Coloca o número acima do círculo */
}

/* Animação do contorno do círculo */
.border__animation {
    position: absolute;
    /* Posição absoluta dentro do círculo */
    top: 0;
    /* Topo do círculo */
    left: 0;
    /* Lado esquerdo do círculo */
    width: 100%;
    /* Largura total */
    height: 100%;
    /* Altura total */
    border: 2px solid transparent;
    /* Borda inicial transparente */
    border-radius: 50%;
    /* Forma circular */
    box-sizing: border-box;
    /* Inclui a borda no cálculo do tamanho */
    z-index: 1;
    /* Coloca a animação abaixo do número */
    transition: border-color 0.5s ease-in-out;
    /* Transição suave da cor da borda */
}

/* Animação da borda */
.border__animation.loading__animation {
    animation: border-loading 2s linear infinite;
    /* Animação de carregamento contínua */
}

/* Keyframes para animação de borda */
@keyframes border-loading {
    0% {
        border-color: transparent;
        /* Sem cor na borda */
        transform: rotate(0deg);
        /* Sem rotação */
    }

    25% {
        border-color: rgb(0, 43, 82) transparent transparent transparent;
        /* Cor azul na borda */
    }

    50% {
        border-color: rgb(0, 43, 82) rgb(0, 43, 82) transparent transparent;
        /* Cor azul na borda */
    }

    75% {
        border-color: rgb(0, 43, 82) rgb(0, 43, 82) rgb(0, 43, 82) transparent;
        /* Cor azul na borda */
    }

    100% {
        border-color: rgb(0, 43, 82) rgb(0, 43, 82) rgb(0, 43, 82) rgb(0, 43, 82);
        /* Cor azul completa na borda */
        transform: rotate(360deg);
        /* Rotação completa */
    }
}

/* Estilo para o texto das etapas */
.step__text {
    font-size: 14px;
    /* Tamanho pequeno da fonte */
    color: #555;
    /* Cor do texto cinza */
}

/* Estilo do container de imagem */
.image__container {
    text-align: center;
    /* Alinha a imagem ao centro */
}

/* Estilo da imagem */
.image__container img {
    width: 400px;
    /* Largura de 400px */
    height: 400px;
    /* Altura de 400px */
    border-radius: 8px;
    /* Bordas arredondadas */
    border: 2px solid #ccc;
    /* Borda cinza */
}

/* Efeito de transição de fade */
.fade-enter-active,
.fade-leave-active {
    transition: opacity 0.5s;
    /* Transição de opacidade */
}

.fade-enter,
.fade-leave-to {
    opacity: 0;
    /* Opacidade zero na entrada e saída */
}

/* Responsividade para telas pequenas */
@media (max-width: 768px) {
    .Banner {
        height: 500px;
        /* Aumenta a altura para telas menores */
    }

    .Banner__item .right {
        display: none;
        /* Oculta o item direito */
    }

    .btns__container {
        flex-direction: column;
        /* Organiza os botões em coluna */
        gap: 15px;
        /* Espaço entre os botões */
    }

    .Precifier__btn,
    .AddImovel__btn {
        padding: 0.75rem 1.5rem;
        /* Diminui o padding */
        font-size: 16px;
        /* Diminui o tamanho da fonte */
    }

    .Range {
        height: auto;
        /* Altura automática */
        padding: 20px 0;
        /* Padding em cima e embaixo */
    }

    .Range__container {
        flex-direction: column;
        /* Organiza os itens em coluna */
        align-items: center;
        /* Alinha ao centro */
    }

    .Range__item {
        width: 100%;
        /* Largura de 100% */
        margin-bottom: 15px;
        /* Espaçamento inferior */
    }

    .Animated {
        height: auto;
        /* Altura automática */
        padding: 20px;
        /* Padding */
    }

    .Internal__Animated {
        flex-direction: column;
        /* Organiza os itens em coluna */
        gap: 20px;
        /* Espaçamento entre os itens */
    }

    .animation__container {
        width: 150px;
        /* Largura reduzida */
        margin: 0 auto;
        /* Centraliza o container */
    }

    .circle {
        width: 40px;
        /* Diminui o tamanho do círculo */
        height: 40px;
        /* Diminui o tamanho do círculo */
    }

    .Animated__Image img {
        width: 200px;
        /* Diminui a largura da imagem */
    }
}

/* Responsividade para telas muito pequenas */
@media (max-width: 480px) {
    .Banner {
        height: 700px;
        /* Aumenta a altura para telas menores */
    }

    .Banner__container {
        display: flex;
        /* Exibe o container como flex */
        align-items: center;
        /* Alinha verticalmente */
        justify-content: center;
        /* Alinha horizontalmente */
    }

    .Banner__item .right {
        display: none;
        /* Oculta o item direito */
    }

    .Precifier__btn,
    .AddImovel__btn {
        width: 100%;
        /* Largura de 100% */
        padding: 0.75rem 0;
        /* Ajusta o padding */
    }

    .Range__item__container {
        text-align: center;
        /* Alinha o texto ao centro */
    }

    .Ranger__P {
        max-width: 200px;
        /* Largura máxima reduzida */
    }

    .Animated__Image img {
        width: 180px;
        /* Diminui a largura da imagem */
    }

    .animation__container {
        width: 120px;
        /* Largura reduzida */
    }

    .circle {
        width: 35px;
        /* Diminui o tamanho do círculo */
        height: 35px;
        /* Diminui o tamanho do círculo */
    }

    .fill {
        transition: height 0.8s ease-in-out;
        /* Animação suave no tamanho */
    }
}
</style>