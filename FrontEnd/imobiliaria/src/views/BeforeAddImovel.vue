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
            <div class="Banner__item"></div>
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
</template>

<script>
export default {
    name: 'BeforeAddImovel',
    data() {
        return {
            words: ["Alugue ", "Venda "], // Lista de frases
            currentWordIndex: 0,
            displayedText: "",
            typingClass: "typing", // Classe inicial para a animação de digitação
        };
    },
    created() {
        this.startTyping();
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

.Precifier__btn:hover{
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

@keyframes blink-caret {
    50% {
        border-color: transparent;
    }
}
</style>