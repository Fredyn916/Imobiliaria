<template>
    <RouterLink to="ViewImovel" class="back-link">Voltar</RouterLink>
    <div class="container">

        <div class="carousel__container">
            <button class="carousel__button prev" @click="prevSlide"><svg version="1.0"
                    xmlns="http://www.w3.org/2000/svg" width="18px" height="18px" viewBox="0 0 512.000000 512.000000"
                    preserveAspectRatio="xMidYMid meet">

                    <g transform="translate(0.000000,512.000000) scale(0.100000,-0.100000)" fill="#000000"
                        stroke="none">
                        <path d="M3742 5093 c-58 -32 -2590 -2340 -2637 -2404 -28 -38 -30 -47 -30
-129 0 -82 2 -91 30 -129 47 -64 2579 -2372 2637 -2404 80 -43 163 -34 235 28
80 68 97 193 37 276 -16 22 -567 531 -1224 1131 -657 600 -1195 1094 -1195
1098 0 4 543 503 1207 1110 932 851 1212 1112 1228 1145 41 85 17 193 -56 253
-71 59 -154 67 -232 25z" />
                    </g>
                </svg>
            </button>

            <div class="carousel">
                <div v-for="(imagem, index) in Imovel.urLsImagens" :key="index" class="carousel__item"
                    v-show="currentIndex === index">
                    <div class="imovel__box__images">
                        <img v-if="imagem" :src="imagem" alt="Imagem do imóvel" class="imovel__image" />
                    </div>
                </div>
            </div>

            <button class="carousel__button next" @click="nextSlide"><svg version="1.0"
                    xmlns="http://www.w3.org/2000/svg" width="18px" height="18px" viewBox="0 0 512.000000 512.000000"
                    preserveAspectRatio="xMidYMid meet">

                    <g transform="translate(0.000000,512.000000) scale(0.100000,-0.100000)" fill="#000000"
                        stroke="none">
                        <path d="M1206 5106 c-46 -17 -99 -67 -121 -113 -24 -51 -21 -134 7 -185 16
-30 378 -366 1228 -1141 663 -604 1205 -1102 1205 -1107 0 -5 -542 -503 -1205
-1107 -850 -775 -1212 -1111 -1228 -1141 -28 -51 -31 -134 -7 -186 24 -50 86
-103 137 -116 48 -13 115 -7 156 14 15 8 614 549 1332 1203 1026 935 1309
1199 1324 1230 24 54 24 152 0 206 -14 31 -300 297 -1324 1229 -718 655 -1318
1197 -1334 1205 -41 21 -124 26 -170 9z" />
                    </g>
                </svg></button>
        </div>

        <div class="contact__box">
            <div class="internal__contact__box">
                <h3>Contate o Anunciante</h3>
                <form @submit.prevent="enviarMensagem" class="contact__form">
                    <div class="form__group">
                        <input type="email" id="email" v-model="email" placeholder="E-mail" required />
                    </div>
                    <div class="name__telefon__container">
                        <div class="form__group1">
                            <input type="text" id="nome" v-model="nome" placeholder="Nome" required />
                        </div>
                        <div class="form__group1">
                            <input type="text" id="telefone" v-model="telefone" placeholder="Telefone" required />
                        </div>
                    </div>
                    <div class="form__group">
                        <textarea id="mensagem" v-model="mensagem" placeholder="Mensagem" required></textarea>
                    </div>
                    <button type="submit" class="submit__btn">Contatar </button>
                    <p class="terms">Ao enviar, você está aceitando os <a href="#">Termos e Condições de uso</a> e as <a
                            href="#">Políticas de Privacidade</a></p>
                </form>
            </div>
        </div>

    </div>

    <div v-if="Imovel && Object.keys(Imovel).length > 0" class="imovel__info">
        <div class="Imovel__area">Terreno : {{ Imovel.area }} m²</div>
        <hr />
        <div class="Imovel__preco"><strong>R$ {{ Imovel.preco }}</strong></div>
        <div class="Imovel__endereco">{{ Imovel.endereco }}</div>
        <div class="Imovel__anos" v-if="Imovel.anos > 0">{{ Imovel.anos }} anos</div>
        <div class="Imovel__anos" v-else>O Imóvel Está em construção</div>
        <div class="Imovel__cep">{{ Imovel.cep }}</div>
        <hr />
        <div class="Imovel__descricao">{{ Imovel.descricao }}</div>
        <hr />
        <div class="Imovel__areasComuns">
            Areas Comuns:
            <ul>
                <li v-for="area in Imovel.areasComuns" :key="area">{{ area }}</li>
            </ul>
        </div>
    </div>
</template>

<script>
import emailjs from 'emailjs-com';

export default {
    name: 'ViewOneImovelRural',
    data() {
        return {
            Imovel: {},
            email: '',
            nome: '',
            telefone: '',
            mensagem: '',
            currentIndex: 0
        };
    },
    mounted() {
        const imovelId = this.$route.query.id;
        if (imovelId) {
            this.carregarImovel(imovelId);
        }
    },
    methods: {
        async carregarImovel(imovelId) {
            try {
                const apiUrl = `https://localhost:7082/Imovel/ListarImovelPorId?id=${imovelId}`;
                const response = await fetch(apiUrl, {
                    method: "GET",
                    headers: {
                        Accept: "application/json",
                    },
                });

                if (!response.ok) {
                    throw new Error('Erro ao buscar detalhes do imóvel.');
                }

                const data = await response.json();
                this.Imovel = data;
                console.log('Detalhes do Imóvel:', this.Imovel);
            } catch (error) {
                console.error('Erro ao carregar detalhes do imóvel:', error);
            }
        },
        prevSlide() {
            if (this.currentIndex > 0) {
                this.currentIndex--;
            } else {
                this.currentIndex = this.Imovel.urLsImagens.length - 1;
            }
        },
        nextSlide() {
            if (this.currentIndex < this.Imovel.urLsImagens.length - 1) {
                this.currentIndex++;
            } else {
                this.currentIndex = 0;
            }
        },
        async enviarMensagem() {
            if (!this.email || !this.email.includes('@')) {
                alert('Por favor, insira um email válido.');
                return;
            }

            if (!this.nome || !this.telefone || !this.mensagem) {
                alert('Por favor, preencha todos os campos.');
                return;
            }

            try {
                const templateParams = {
                    User__Email: this.email,
                    subject: `Seu Email foi enviado com sucesso! ${this.nome}, ${this.telefone}`,
                    message: this.mensagem
                };

                const response = await emailjs.send(
                    'service_a15zhqh', // Substitua pelo seu Service ID do EmailJS
                    'template_f0t2ea8', // Substitua pelo seu Template ID do EmailJS
                    templateParams,
                    'sMDnLAmKs04K02KCr' // Substitua pelo seu User ID do EmailJS
                );

                alert('Email enviado com sucesso! Verifique sua caixa de entrada.');
            } catch (error) {
                alert('Ocorreu um erro ao enviar o email.');
                console.error(error);
            }
        }
    }
};
</script>
<style>
.back-link {
    display: inline-block;
    padding: 0.95rem 1rem;
    margin: 20px 20px;
    font-size: 16px;
    font-weight: bold;
    text-align: center;
    text-decoration: none;
    color: #ffffff;
    background-color: rgb(0, 43, 82);
    border-radius: 5px;
    transition: background-color 0.3s, transform 0.3s;
    box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
}

.back-link:hover {
    background-color: #1A5276;
    transform: translateY(-2px);
}

.container {
    display: flex;
    padding-right: 30%;
    box-sizing: border-box;
}


.carousel__container {
    flex-grow: 1;
    display: flex;
    align-items: center;
    justify-content: center;
    position: relative;
    overflow: hidden;
    width: 60%;
    height: 80%;
}

.carousel {
    display: flex;
    width: 100%;
    height: 100%;
    transition: transform 0.3s ease-in-out;
}

.carousel__item {
    display: flex;
    justify-content: center;
    align-items: center;
    width: 100%;
    height: 100%;
}

.imovel__box__images {
    width: 800px;
    height: 500px;
    display: flex;
    justify-content: center;
    align-items: center;
}

.imovel__image {
    width: 100%;
    height: 100%;
    object-fit: cover;
    border-radius: 6px;
}


.carousel__button {
    position: absolute;
    top: 50%;
    transform: translateY(-50%);
    background-color: rgba(255, 255, 255, 0.8);
    color: #333;
    font-size: 2.5rem;
    border: none;
    cursor: pointer;
    display: flex;
    align-items: center;
    justify-content: center;
    padding: 15px;
    z-index: 10;
    border-radius: 50%;
    transition: background-color 0.3s ease, transform 0.3s ease;
    box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
    width: 60px;
    height: 60px;
}

.carousel__button:hover {
    background-color: #ededed;
    transform: translateY(-50%) scale(1.1);
}

.carousel__button:active {
    transform: translateY(-50%) scale(1);
}

.carousel__button.prev {
    left: 15px;
}

.carousel__button.next {
    right: 15px;
}


.contact-box {
    width: 30%;
    padding: 20px;
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
    position: absolute;
    top: 0;
    right: 0;
    height: 100vh;
    background-color: transparent;
    overflow-y: auto;
}

.internal__contact__box {
    width: 100%;
    text-align: left;
    padding: 20px;
    border: 3px solid #d4d4d4;
    border-radius: 9px;
}

.internal__contact__box p {
    font-weight: 600;
    font-size: 14px;
}

input[type="email"],
input[type="text"],
textarea {
    width: 100%;
    padding: 0.8rem;
    border: 3px solid #ededed;
    border-radius: 9px;
    margin-bottom: 10px;
}

.name__telefon__container {
    display: flex;
    width: 100%;
    gap: 10px;
}

.form__group1 {
    width: 50%;
}

.submit__btn {
    width: 100%;
    padding: 1rem;
    border-radius: 9px;
    border: 3px solid #ededed;
    color: #000;
    font-weight: 600;
    font-family: "Funnel Display", sans-serif;
}

.submit__btn:hover {
    cursor: pointer;
}

.terms {
    font-size: 12px;
    margin-top: 10px;
}

.terms a {
    color: #3498db;
    text-decoration: none;
}

.terms a:hover {
    text-decoration: underline;
}

.imovel__info {
    width: 100%;
    max-width: 65%;
    padding: 20px;
    background-color: #ffffff;
    border-radius: 9px;
    margin-top: 20px;
}

.imovel__info div {
    margin-bottom: 10px;
}

.imovel__info .Imovel__preco {
    font-size: 1.5rem;
    font-weight: bold;
    color: #000;
}

.imovel__info .Imovel__area,
.imovel__info .Imovel__endereco,
.imovel__info .Imovel__cep {
    font-size: 1.2rem;
    color: #555;
}

.imovel__info .Imovel__descricao {
    font-size: 1rem;
    color: #777;
}

.imovel__info .Imovel__anos {
    font-size: 1.1rem;
    font-weight: 600;
}

.imovel__info .Imovel__areasComuns ul {
    list-style-type: none;
    padding: 0;
}

.imovel__info .Imovel__areasComuns li {
    margin-left: 1rem;
    font-size: 1rem;
}

/* Responsividade */
@media (max-width: 768px) {
    .container {
        flex-direction: column;
        padding: 20px;
    }

    .carousel__container {
        width: 100%;
        height: auto;
    }

    .carousel__button {
        width: 40px;
        height: 40px;
    }

    .imovel__box__images {
        width: 100%;
        height: 300px;
    }

    .contact__box {
        position: static;
        width: 100%;
        height: auto;
        margin-top: 20px;
        padding: 10px;
    }

    .internal__contact__box {
        padding: 10px;
    }

    .name__telefon__container {
        flex-direction: column;
        gap: 5px;
    }

    .form__group1 {
        width: 100%;
    }

    .submit__btn {
        padding: 0.8rem;
    }

    .terms {
        font-size: 10px;
    }

    .imovel__info {
        width: 100%;
        max-width: 100%;
        padding: 15px;
    }

    .imovel__info .Imovel__preco {
        font-size: 1.3rem;
    }

    .imovel__info .Imovel__area,
    .imovel__info .Imovel__endereco,
    .imovel__info .Imovel__cep {
        font-size: 1rem;
    }

    .imovel__info .Imovel__descricao {
        font-size: 0.9rem;
    }

    .imovel__info .Imovel__anos {
        font-size: 1rem;
    }
}

@media (max-width: 480px) {
    .back-link {
        font-size: 14px;
        padding: 0.75rem;
    }

    .carousel__button {
        width: 35px;
        height: 35px;
    }

    .imovel__box__images {
        height: 250px;
    }

    .contact__box {
        padding: 8px;
    }

    .internal__contact__box {
        padding: 8px;
    }

    .name__telefon__container {
        flex-direction: column;
        gap: 5px;
    }

    .form__group1 {
        width: 100%;
    }

    .submit__btn {
        padding: 0.7rem;
    }

    .imovel__info {
        padding: 10px;
    }
}
</style>
