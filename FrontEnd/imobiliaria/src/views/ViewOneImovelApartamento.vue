<template>
    <RouterLink to="ViewImovel" class="back-link">Voltar</RouterLink>
    <div class="container">

        <div class="carousel-container">
            <button class="carousel-button prev" @click="prevSlide">❮</button>

            <div class="carousel">
                <div v-for="(imagem, index) in Imovel.urLsImagens" :key="index" class="carousel-item"
                    v-show="currentIndex === index">
                    <div class="imovel-box-images">
                        <img v-if="imagem" :src="imagem" alt="Imagem do imóvel" class="imovel-image" />
                    </div>
                </div>
            </div>

            <button class="carousel-button next" @click="nextSlide">❯</button>
        </div>

        <div class="contact-box">
            <div class="internal__contact__box">
                <h3>Contate o Anunciante</h3>
                <form @submit.prevent="enviarMensagem" class="contact-form">
                    <div class="form-group">
                        <input type="email" id="email" v-model="email" placeholder="E-mail" required />
                    </div>
                    <div class="name__telefon__container">
                        <div class="form-group1">
                            <input type="text" id="nome" v-model="nome" placeholder="Nome" required />
                        </div>
                        <div class="form-group1">
                            <input type="text" id="telefone" v-model="telefone" placeholder="Telefone" required />
                        </div>
                    </div>
                    <div class="form-group">
                        <textarea id="mensagem" v-model="mensagem" placeholder="Mensagem" required></textarea>
                    </div>
                    <button type="submit" class="submit-btn">Contatar </button>
                    <p class="terms">Ao enviar, você está aceitando os <a href="#">Termos e Condições de uso</a> e as <a
                            href="#">Políticas de Privacidade</a></p>
                </form>
            </div>
        </div>

    </div>

    <div v-if="Imovel && Object.keys(Imovel).length > 0" class="imovel-info">
        <div class="Imovel__area">Terreno : {{ Imovel.area }} m²</div>
        <div class="Imovel__preco"><strong>R$ {{ Imovel.preco }}</strong></div>
        <div class="Imovel__endereco">{{ Imovel.endereco }}</div>
        <div class="Imovel__anos" v-if="Imovel.anos > 0">{{ Imovel.anos }} anos</div>
        <div class="Imovel__anos" v-else>O Imóvel Está em construção</div>
        <div class="Imovel__cep">{{ Imovel.cep }}</div>
        <div class="Imovel__descricao">{{ Imovel.descricao }}</div>
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
    name: 'ViewOneImovelApartamento',
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
.container {
    display: flex;
    padding-right: 30%;
    box-sizing: border-box;
    padding-top: 100px;
}


.back-link {
    display: inline-block;
    margin-bottom: 20px;
    color: #3498db;
    text-decoration: none;
    font-size: 1.1rem;
    font-weight: 600;
    transition: color 0.3s;
    width: 50px;
    height: 50px;
    padding: 20px;
}

.back-link:hover {
    color: #1d70b8;
    text-decoration: underline;
}

.carousel-container {
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

.carousel-item {
    display: flex;
    justify-content: center;
    align-items: center;
    width: 100%;
    height: 100%;
}

.imovel-box-images {
    width: 900px;
    height: 600px;
    display: flex;
    justify-content: center;
    align-items: center;
}

.imovel-image {
    width: 100%;
    height: 100%;
    object-fit: cover;
    border-radius: 6px;
}


.carousel-button {
    position: absolute;
    top: 50%;
    transform: translateY(-50%);
    background-color: rgba(0, 0, 0, 0.5);
    border: none;
    color: white;
    font-size: 2rem;
    cursor: pointer;
    z-index: 1;
}

.carousel-button.prev {
    left: 10px;
}

.carousel-button.next {
    right: 10px;
}

.contact-box {
    width: 30%;
    padding: 20px;
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
    position: fixed;
    top: 0;
    right: 0;
    height: 100vh;
    background-color: transparent;
    z-index: 1000;
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

.form-group1 {
    width: 50%;
}

.submit-btn {
    width: 100%;
    padding: 1rem;
    border-radius: 9px;
    border: 3px solid #ededed;
    color: #000;
    font-weight: 600;
    font-family: "Funnel Display", sans-serif;
}

.submit-btn:hover {
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

.imovel-info {
    width: 100%;
    max-width: 65%;
    padding: 20px;
    background-color: #ffffff;
    border-radius: 9px;
    margin-top: 20px;
}

.imovel-info div {
    margin-bottom: 10px;
}

.imovel-info .Imovel__preco {
    font-size: 1.5rem;
    font-weight: bold;
    color: #000;
}

.imovel-info .Imovel__area,
.imovel-info .Imovel__endereco,
.imovel-info .Imovel__cep {
    font-size: 1.2rem;
    color: #555;
}

.imovel-info .Imovel__descricao {
    font-size: 1rem;
    color: #777;
}

.imovel-info .Imovel__anos {
    font-size: 1.1rem;
    font-weight: 600;
}

.imovel-info .Imovel__areasComuns ul {
    list-style-type: none;
    padding: 0;
}

.imovel-info .Imovel__areasComuns li {
    margin-left: 1rem;
    font-size: 1rem;
}
</style>
