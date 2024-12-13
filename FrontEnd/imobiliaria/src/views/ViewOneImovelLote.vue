<template>
    <RouterLink to="ViewImovel" class="back-link">Voltar</RouterLink>
    <hr />
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

        <div class="contact-box">
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
                    <button type="submit" class="submit-btn">Contatar </button>
                    <p class="terms">Ao enviar, você está aceitando os <a href="#">Termos e Condições de uso</a> e as <a
                            href="#">Políticas de Privacidade</a></p>
                </form>
            </div>
        </div>

    </div>

    <div v-if="Imovel && Object.keys(Imovel).length > 0" class="imovel_info">
        <div class="Imovel__area">Terreno : {{ Imovel.area }} m²</div>
        <hr />
        <div class="Imovel__preco"><strong>R$ {{ Imovel.preco }}</strong></div>
        <div class="Imovel__endereco">{{ Imovel.endereco }}</div>
        <div class="Imovel__anos" v-if="Imovel.anos > 0">{{ Imovel.anos }} anos</div>
        <div class="Imovel__anos" v-else>O Imóvel Está em construção</div>
        <div class="Imovel__cep">{{ Imovel.cep }}</div>
        <hr />
        <div class="Imovel__titulo" style="color: black; font-weight: 600; font-size: 20px;">{{ Imovel.titulo }}</div>
        <div class="Imovel__descricao">{{ Imovel.descricao }}</div>
        <hr />
        <div v-if="!Imovel.areasComuns || Imovel.areasComuns.length === 0"></div>
        <div class="Imovel__areasComuns" v-else>
            <h2>Areas Comuns:</h2>
            <ul>
                <li v-for="area in Imovel.areasComuns" :key="area">{{ area }}</li>
            </ul>
        </div>
        <hr />
    </div>
</template>

<script>
import emailjs from 'emailjs-com';

export default {
    name: 'ViewOneImovelLote',
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
/* Estilo para o link de retorno */
.back-link {
    display: inline-block;
    /* Torna o link um bloco em linha */
    padding: 0.95rem 1rem;
    /* Adiciona preenchimento em torno do texto */
    margin: 20px 20px;
    /* Define a margem em torno do link */
    font-size: 16px;
    /* Tamanho da fonte */
    font-weight: bold;
    /* Deixa o texto em negrito */
    text-align: center;
    /* Alinha o texto no centro */
    text-decoration: none;
    /* Remove a sublinhado padrão */
    color: #ffffff;
    /* Cor do texto */
    background-color: rgb(0, 43, 82);
    /* Cor de fundo do link */
    border-radius: 5px;
    /* Bordas arredondadas */
    transition: background-color 0.3s, transform 0.3s;
    /* Transição suave para as mudanças */
    box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
    /* Sombra suave */
}

/* Estilo ao passar o mouse sobre o link */
.back-link:hover {
    background-color: #1A5276;
    /* Altera a cor de fundo */
    transform: translateY(-2px);
    /* Movimenta o link ligeiramente para cima */
}

/* Contêiner principal */
.container {
    display: flex;
    /* Usa o modelo flexbox */
    padding-right: 30%;
    padding-top: 20px;
    /* Adiciona preenchimento à direita */
    box-sizing: border-box;
    /* Inclui o padding na largura total */
}

/* Contêiner do carrossel de imagens */
.carousel__container {
    flex-grow: 1;
    /* Faz o contêiner crescer conforme necessário */
    display: flex;
    /* Usa flexbox */
    align-items: center;
    /* Alinha os itens verticalmente no centro */
    justify-content: center;
    /* Alinha os itens horizontalmente no centro */
    position: relative;
    /* Define a posição como relativa */
    overflow: hidden;
    /* Esconde qualquer conteúdo que ultrapasse o limite */
    width: 60%;
    /* Define a largura do contêiner */
    height: 80%;
    /* Define a altura do contêiner */
}

/* Carrossel de itens */
.carousel {
    display: flex;
    /* Flexbox para os itens */
    width: 100%;
    /* Largura do carrossel é 100% do seu contêiner */
    height: 100%;
    /* Altura do carrossel é 100% do seu contêiner */
    transition: transform 0.3s ease-in-out;
    /* Transição suave para movimentação */
}

/* Estilo dos itens do carrossel */
.carousel__item {
    display: flex;
    /* Flexbox para os itens */
    justify-content: center;
    /* Alinha os itens horizontalmente */
    align-items: center;
    /* Alinha os itens verticalmente */
    width: 100%;
    /* Largura de 100% */
    height: 100%;
    /* Altura de 100% */
}

/* Contêiner da imagem do imóvel */
.imovel__box__images {
    width: 800px;
    /* Largura fixa */
    height: 500px;
    /* Altura fixa */
    display: flex;
    /* Flexbox para centralizar a imagem */
    justify-content: center;
    /* Centraliza horizontalmente */
    align-items: center;
    /* Centraliza verticalmente */
}

/* Estilo para a imagem do imóvel */
.imovel__image {
    width: 100%;
    /* A imagem ocupa 100% do contêiner */
    height: 100%;
    /* A imagem ocupa 100% da altura do contêiner */
    object-fit: cover;
    /* Ajusta a imagem para cobrir totalmente o espaço */
    border-radius: 6px;
    /* Bordas arredondadas na imagem */
}

/* Estilo para os botões de navegação do carrossel */
.carousel__button {
    position: absolute;
    /* Posiciona os botões de forma absoluta */
    top: 50%;
    /* Posiciona os botões no meio verticalmente */
    transform: translateY(-50%);
    /* Centraliza verticalmente */
    background-color: rgba(255, 255, 255, 0.8);
    /* Cor de fundo transparente */
    color: #333;
    /* Cor do texto */
    font-size: 2.5rem;
    /* Tamanho da fonte */
    border: none;
    /* Remove a borda padrão */
    cursor: pointer;
    /* Mostra o cursor como pointer ao passar o mouse */
    display: flex;
    /* Flexbox para centralizar o conteúdo */
    align-items: center;
    /* Alinha o conteúdo no centro vertical */
    justify-content: center;
    /* Alinha o conteúdo no centro horizontal */
    padding: 15px;
    /* Preenchimento ao redor do botão */
    z-index: 1;
    /* Garante que o botão fique sobre outros elementos */
    border-radius: 50%;
    /* Faz o botão redondo */
    transition: background-color 0.3s ease, transform 0.3s ease;
    /* Transições suaves para cor e transformação */
    box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
    /* Sombra suave */
    width: 60px;
    /* Largura do botão */
    height: 60px;
    /* Altura do botão */
}

/* Estilo ao passar o mouse sobre os botões */
.carousel__button:hover {
    background-color: #ededed;
    /* Altera a cor de fundo */
    transform: translateY(-50%) scale(1.1);
    /* Aumenta o tamanho do botão */
}

/* Estilo ao clicar nos botões */
.carousel__button:active {
    transform: translateY(-50%) scale(1);
    /* Volta ao tamanho normal */
}

/* Posicionamento do botão anterior */
.carousel__button.prev {
    left: 15px;
    /* Posiciona o botão à esquerda */
}

/* Posicionamento do botão próximo */
.carousel__button.next {
    right: 15px;
    /* Posiciona o botão à direita */
}

/* Caixa de contato */
.contact-box {
    width: 30%;
    /* Largura do contêiner */
    padding-top: 60px;
    /* Preenchimento interno */
    display: flex;
    /* Flexbox para o layout */
    flex-direction: column;
    /* Organiza os itens na coluna */
    align-items: center;
    /* Alinha os itens no centro */
    justify-content: center;
    /* Centraliza o conteúdo */
    position: absolute;
    /* Posição fixa */
    top: 0;
    /* Alinha ao topo */
    right: 0;
    /* Alinha à direita */
    height: 100vh;
    /* Ocupa toda a altura da tela */
    background-color: transparent;
    /* Cor de fundo transparente */
    overflow-y: auto;
    /* Permite rolagem vertical */
}

/* Caixa interna de contato */
.internal__contact__box {
    width: 100%;
    /* Ocupa 100% da largura do contêiner */
    text-align: left;
    /* Alinha o texto à esquerda */
    padding: 20px;
    /* Preenchimento interno */
    border: 3px solid #d4d4d4;
    /* Borda suave */
    border-radius: 9px;
    /* Bordas arredondadas */
}

/* Estilo dos parágrafos dentro da caixa de contato */
.internal__contact__box p {
    font-weight: 600;
    /* Texto em negrito */
    font-size: 14px;
    /* Tamanho da fonte */
}

/* Estilo dos campos de entrada */
input[type="email"],
input[type="text"],
textarea {
    width: 100%;
    /* Largura total */
    padding: 0.8rem;
    /* Preenchimento interno */
    border: 3px solid #ededed;
    /* Borda leve */
    border-radius: 9px;
    /* Bordas arredondadas */
    margin-bottom: 10px;
    /* Espaço abaixo dos campos */
}

/* Contêiner para nome e telefone */
.name__telefon__container {
    display: flex;
    /* Flexbox para o layout */
    width: 100%;
    /* Largura total */
    gap: 10px;
    /* Espaço entre os campos */
}

/* Estilo para o grupo de campos de nome e telefone */
.form__group1 {
    width: 50%;
    /* Largura de 50% */
}

/* Botão de envio */
.submit-btn {
    width: 100%;
    /* Largura total */
    padding: 1rem;
    /* Preenchimento interno */
    border-radius: 9px;
    /* Bordas arredondadas */
    border: 3px solid #ededed;
    /* Borda suave */
    color: #000;
    /* Cor do texto */
    font-weight: 600;
    /* Texto em negrito */
    font-family: "Funnel Display", sans-serif;
    /* Fonte específica */
}

/* Estilo ao passar o mouse sobre o botão */
.submit-btn:hover {
    cursor: pointer;
    /* Cursor de ponteiro */
}

/* Estilo para os termos e condições */
.terms {
    font-size: 12px;
    /* Tamanho da fonte */
    margin-top: 10px;
    /* Espaço acima */
}

/* Estilo para os links nos termos */
.terms a {
    color: #3498db;
    /* Cor azul */
    text-decoration: none;
    /* Remove sublinhado */
}

/* Estilo para o link ao passar o mouse */
.terms a:hover {
    text-decoration: underline;
    /* Sublinha ao passar o mouse */
}

/* Informações do imóvel */
.imovel_info {
    width: 100%;
    /* Largura total */
    max-width: 65%;
    /* Largura máxima */
    padding: 20px;
    /* Preenchimento interno */
    background-color: #ffffff;
    /* Cor de fundo branca */
    border-radius: 9px;
    /* Bordas arredondadas */
    margin-top: 20px;
    /* Espaço superior */
    display: flex;
    /* Flexbox */
    flex-direction: column;
    /* Organiza os itens em coluna */
    gap: 20px;
    /* Espaço entre os itens */
}

/* Estilo para as divisões internas */
.imovel_info div {
    margin-bottom: 10px;
    /* Espaço inferior */
}

/* Estilo para o preço do imóvel */
.imovel_info .Imovel__preco {
    font-size: 1.5rem;
    /* Tamanho da fonte */
    font-weight: bold;
    /* Texto em negrito */
    color: #000;
    /* Cor do texto */
}

/* Estilo para área, endereço e CEP do imóvel */
.imovel_info .Imovel__area,
.imovel_info .Imovel__endereco,
.imovel_info .Imovel__cep {
    font-size: 1.2rem;
    /* Tamanho da fonte */
    color: #555;
    /* Cor cinza */
}

/* Estilo para a descrição do imóvel */
.imovel_info .Imovel__descricao {
    font-size: 1rem;
    /* Tamanho da fonte */
    color: #777;
    /* Cor cinza claro */
}

/* Estilo para o ano de construção */
.imovel_info .Imovel__anos {
    font-size: 1.1rem;
    /* Tamanho da fonte */
    font-weight: 600;
    /* Texto em negrito */
}

/* Estilo para as áreas comuns do imóvel */
.imovel_info .Imovel__areasComuns ul {
    padding-left: 40px;
    /* Remove o preenchimento da lista */
}

.Imovel__areasComuns h2 {
    color: #000;
    font-weight: 600;
    padding-bottom: 20px
}

/* Estilo para cada item das áreas comuns */
.imovel_info .Imovel__areasComuns li {
    margin-left: 1rem;
    /* Espaço à esquerda */
    font-size: 1rem;
    /* Tamanho da fonte */
    padding-bottom: 10px;
    /* padding em baixo de cada item */
}

/* Responsividade para telas menores que 768px */
@media (max-width: 768px) {
    .container {
        flex-direction: column;
        /* Alinha os itens em coluna */
        padding: 20px;
        /* Ajusta o preenchimento */
    }

    .carousel__container {
        width: 100%;
        /* Largura total */
        height: auto;
        /* Altura automática */
    }

    .carousel__button {
        width: 40px;
        /* Tamanho menor para os botões */
        height: 40px;
    }

    .imovel__box__images {
        width: 100%;
        /* Largura total */
        height: 300px;
        /* Altura reduzida */
    }

    .contact-box {
        position: static;
        /* Muda para posição estática */
        width: 100%;
        /* Largura total */
        height: auto;
        /* Altura automática */
        margin-top: 20px;
        /* Espaço superior */
        padding: 10px;
        /* Preenchimento reduzido */
    }

    .internal__contact__box {
        padding: 10px;
        /* Preenchimento reduzido */
    }

    .name__telefon__container {
        flex-direction: column;
        /* Alinha os itens em coluna */
        gap: 5px;
        /* Reduz o espaçamento */
    }

    .form__group1 {
        width: 100%;
        /* Largura total */
    }

    .submit-btn {
        padding: 0.8rem;
        /* Reduz o preenchimento */
    }

    .terms {
        font-size: 10px;
        /* Fonte menor */
    }

    .imovel_info {
        width: 100%;
        /* Largura total */
        max-width: 100%;
        /* Largura total */
        padding: 15px;
        /* Preenchimento ajustado */
    }

    .imovel_info .Imovel__preco {
        font-size: 1.3rem;
        /* Tamanho reduzido */
    }

    .imovel_info .Imovel__area,
    .imovel_info .Imovel__endereco,
    .imovel_info .Imovel__cep {
        font-size: 1rem;
        /* Tamanho reduzido */
    }

    .imovel_info .Imovel__descricao {
        font-size: 0.9rem;
        /* Tamanho reduzido */
    }

    .imovel_info .Imovel__anos {
        font-size: 1rem;
        /* Tamanho reduzido */
    }
}

/* Responsividade para telas menores que 480px */
@media (max-width: 480px) {
    .back-link {
        font-size: 14px;
        /* Fonte menor */
        padding: 0.75rem;
        /* Preenchimento reduzido */
    }

    .carousel__button {
        width: 35px;
        /* Botões ainda menores */
        height: 35px;
    }

    .imovel__box__images {
        height: 250px;
        /* Reduz a altura da imagem */
    }

    .contact-box {
        padding: 8px;
        /* Preenchimento reduzido */
    }

    .internal__contact__box {
        padding: 8px;
        /* Preenchimento reduzido */
    }

    .name__telefon__container {
        flex-direction: column;
        /* Alinha os itens em coluna */
        gap: 5px;
        /* Espaço reduzido */
    }

    .form__group1 {
        width: 100%;
        /* Largura total */
    }

    .submit-btn {
        padding: 0.7rem;
        /* Reduz o preenchimento */
    }

    .imovel_info {
        padding: 10px;
        /* Ajuste no preenchimento */
    }
}
</style>
