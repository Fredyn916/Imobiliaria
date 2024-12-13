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
                        <img src="C:\Users\Alunos\Pictures\Apresentação tarde\Site Imobiliaria\Trabalho Semestral\FrontEnd\imobiliaria\src\Images\bg.png" alt="Step image" />
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
                { id: 1, text: 'Localize seu imóvel no mapa' },
                { id: 2, text: 'Diga-nos como é' },
                { id: 3, text: 'Envie fotos e vídeos' },
                { id: 4, text: 'Escolha um plano'}
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
.Banner {
    width: 100%;
    height: 450px;
    background: url('@/Images/bg.png') no-repeat center center;
    background-size: cover;
    display: flex;
    justify-content: center;
}

.Banner__container {
    width: 100%;
    height: 450px;
    display: flex;
}

.Banner__item {
    flex: 1;
    height: 100%;
    width: 50%;
    display: flex;
    text-align: left;
    flex-direction: column;
    justify-content: center;
    padding-inline: 3rem;
    gap: 20px;
}


.typing {
    border-right: 2px solid #000;
    animation: blink-caret 0.75s step-end infinite;
}


.btns__container {
    display: flex;
    align-items: center;
    gap: 10px;
}

.Precifier__btn {
    padding: 0.90rem 2rem;
    border: 3px solid white;
    border-radius: 8px;
    background-color: transparent;
    color: #FFF;
    font-weight: 600;
    font-size: 18px;
    transition: .3s;
}

.Precifier__btn:hover {
    transform: scale(1.04);
    cursor: pointer;
}

.AddImovel__btn {
    padding: 0.90rem 2rem;
    background-color: rgb(0, 43, 82);
    border: none;
    border-radius: 8px;
    color: #FFF;
    font-weight: 600;
    font-size: 18px;
    transition: .3s;
}

.AddImovel__btn:hover {
    background-color: #1A5276;
    transform: scale(1.04);
    cursor: pointer;
}

.Banner__item__color {
    color: #FFF;
    font-weight: 600;
    font-size: 1rem;
}

.typing__text {
    color: rgb(0, 43, 82);
}


.Range {
    width: 100%;
    height: 200px;
    background-color: #ededed;
}

.Range__container {
    width: 100%;
    height: 100%;
    display: flex;
}

.Range__item {
    flex: 1;
    height: 100%;
    display: flex;
    align-items: center;
    justify-content: center;
}

.Range__item__container {
    display: flex;
    flex-direction: column;
}

.Ranger__P {
    max-width: 250px;
}

.Animated {
    width: 100%;
    height: 500px;
    display: flex;
    text-align: center;
    flex-direction: column;
    gap: 40px;
}

.Internal__Animated {
    display: flex;
    justify-content: space-around;
}

.animation__container {
    position: relative;
    width: 50%;
    margin: auto;
    display: flex;
    flex-direction: column;
    justify-content: center;
    padding-left: 200px;
    flex: 1;
}

.Animated__Image {
    flex: 1;
    width: 50%;
    height: 100%;
    display: flex;
    justify-content: center;
    align-items: center;
}

.container {
    display: flex;
    align-items: center;
    justify-content: center;
}

.step {
    display: flex;
    align-items: center;
    margin-bottom: 20px;
}

.circle {
    position: relative;
    width: 50px;
    height: 50px;
    border: 2px solid white;
    border-radius: 50%;
    display: flex;
    align-items: center;
    justify-content: center;
    overflow: hidden;
    margin-right: 10px;
}

.circle.active {
    border-color: #4caf50;
    /* Borda verde para etapas ativas */
}

.number {
    font-size: 16px;
    font-weight: bold;
    z-index: 2;
}

.border__animation {
    position: absolute;
    top: 0;
    left: 0;
    width: 100%;
    height: 100%;
    border: 2px solid transparent;
    border-radius: 50%;
    box-sizing: border-box;
    z-index: 1;
    transition: border-color 0.5s ease-in-out;
    /* Transição suave */
}

.border__animation.loading__animation {
    animation: border-loading 2s linear infinite;
}

@keyframes border-loading {
    0% {
        border-color: transparent;
        transform: rotate(0deg);
    }

    25% {
        border-color: #4caf50 transparent transparent transparent;
    }

    50% {
        border-color: #4caf50 #4caf50 transparent transparent;
    }

    75% {
        border-color: #4caf50 #4caf50 #4caf50 transparent;
    }

    100% {
        border-color: #4caf50 #4caf50 #4caf50 #4caf50;
        transform: rotate(360deg);
    }
}

.step__text {
    font-size: 14px;
    color: #555;
}

.image__container {
    text-align: center;
}

.image__container img {
    width: 400px;
    height: 400px;
    border-radius: 8px;
    border: 2px solid #ccc;
}

.fade-enter-active,
.fade-leave-active {
    transition: opacity 0.5s;
}

.fade-enter,
.fade-leave-to {
    opacity: 0;
}

/* Responsividade para telas pequenas (tablets e celulares maiores) */
@media (max-width: 768px) {
    .Banner {
        height: 500px;
    }


    .Banner__item .right {
        display: none;
    }

    .btns__container {
        flex-direction: column;
        gap: 15px;
    }

    .Precifier__btn,
    .AddImovel__btn {
        padding: 0.75rem 1.5rem;
        font-size: 16px;
    }

    .Range {
        height: auto;
        padding: 20px 0;
    }

    .Range__container {
        flex-direction: column;
        align-items: center;
    }

    .Range__item {
        width: 100%;
        margin-bottom: 15px;
    }

    .Animated {
        height: auto;
        padding: 20px;
    }

    .Internal__Animated {
        flex-direction: column;
        gap: 20px;
    }

    .animation__container {
        width: 150px;
        margin: 0 auto;
    }

    .circle {
        width: 40px;
        height: 40px;
    }

    .Animated__Image img {
        width: 200px;
    }
}

/* Responsividade para telas muito pequenas (smartphones) */
@media (max-width: 480px) {
    .Banner {
        height: 700px;
    }

    .Banner__container {
        display: flex;
        align-items: center;
        justify-content: center;
    }

    .Banner__item .right {
        display: none;
    }

    .Precifier__btn,
    .AddImovel__btn {
        width: 100%;
        padding: 0.75rem 0;
    }

    .Range__item__container {
        text-align: center;
    }

    .Ranger__P {
        max-width: 200px;
    }

    .Animated__Image img {
        width: 180px;
    }

    .animation__container {
        width: 120px;
    }

    .circle {
        width: 35px;
        height: 35px;
    }

    .fill {
        transition: height 0.8s ease-in-out;
    }
}
</style>