<template>
  <footer class="footer">
    <!-- Seção de Newsletter -->
    <div class="footer__newsletter">
      <h2>Inscreva-se na nossa Newsletter</h2>
      <p>Receba as últimas novidades e ofertas diretamente no seu e-mail.</p>
      <div class="newsletter__form">
        <input type="email" placeholder="Digite seu e-mail" class="newsletter__input" v-model="email" />
        <button class="newsletter__button" @click="sendEmail">Inscrever</button>
      </div>
    </div>

    <!-- Logo no centro do footer -->
    <div class="footer__logo-container">
      <img src="https://res.cloudinary.com/fredmarques/image/upload/v1734056496/LogoSweetHome_tzwyjv.png"
        alt="Logo Do Site" class="footer__logo" />
    </div>

    <!-- Seções do footer em colunas -->
    <div class="footer__sections">
      <div class="footer__section">
        <h3>Nome do site</h3>
        <ul>
          <li><a href="#">Buscar imóveis</a></li>
          <li>
            <RouterLink to="AnunciarSeuImovel">Anunciar</RouterLink>
          </li>
        </ul>
      </div>

      <div class="footer__section">
        <h3>Anunciantes</h3>
        <ul>
          <li><a href="#">Imobiliárias</a></li>
          <li><a href="#">Parcerias</a></li>
        </ul>
      </div>

      <div class="footer__section">
        <h3>Links Úteis</h3>
        <ul>
          <li>
            <RouterLink to="Precificador">Precificador</RouterLink>
          </li>
        </ul>
      </div>
    </div>

    <!-- Seção de Redes Sociais -->
    <div class="footer__social">
      <a href="#" class="social__icon"><font-awesome-icon icon="fa-brands fa-facebook" /></a>
      <a href="#" class="social__icon"><font-awesome-icon icon="fa-brands fa-twitter" /></a>
      <a href="#" class="social__icon"><font-awesome-icon icon="fa-brands fa-instagram" /></a>
    </div>

    <!-- Copyright no final -->
    <div class="footer__bottom">
      <span>© 2024 Nome do site. Todos os direitos reservados.</span>

      <RouterLink to="TermosDeUso" class="terms">Termos de uso | Privacidade</RouterLink>
    </div>
  </footer>
</template>
<script>
import emailjs from 'emailjs-com';

export default {
  name: 'Footer',
  data() {
    return {
      email: '',
    };
  },
  methods: {
    async sendEmail() {
      if (!this.email) {
        alert('Por favor, insira um email válido.');
        return;
      }

      try {
        const templateParams = {
          User__Email: this.email,
          subject: 'Novos imóveis disponíveis para você!',
          message: `
        Olá, temos novidades para você!
        Confira os imóveis disponíveis na sua região com condições exclusivas.
        Não perca essa oportunidade de encontrar o imóvel dos seus sonhos.
      `,
        };

        const response = await emailjs.send(
          'service_a15zhqh', // Substitua pelo seu Service ID do EmailJS
          'template_f0t2ea8', // Substitua pelo seu Template ID do EmailJS
          templateParams,
          'sMDnLAmKs04K02KCr' // Substitua pelo seu User ID do EmailJS
        );

        alert('Email enviado com sucesso! Verifique sua caixa de entrada.');
        this.email = ''; // Limpa o campo
      } catch (error) {
        alert('Ocorreu um erro ao enviar o email.');
        console.error(error);
      }
    }
  },
};
</script>

<style scoped>
/* Estilo principal do rodapé */
.footer {
  background-color: #f3f7f8;
  /* Cor de fundo do rodapé */
  color: #2C3E50;
  /* Cor do texto */
  padding: 2rem;
  /* Espaçamento interno */
  display: flex;
  /* Usando Flexbox para o layout */
  flex-direction: column;
  /* Organiza os itens do rodapé em coluna */
  align-items: center;
  /* Centraliza os itens horizontalmente */
  text-align: center;
  /* Alinha o texto ao centro */
}

/* Estilo da seção de newsletter */
.footer__newsletter {
  margin-bottom: 2rem;
  /* Espaçamento inferior */
}

/* Estilo do título da seção de newsletter */
.footer__newsletter h2 {
  font-size: 1.5rem;
  /* Tamanho da fonte */
  margin-bottom: 0.5rem;
  /* Espaçamento inferior */
}

/* Estilo do parágrafo da seção de newsletter */
.footer__newsletter p {
  margin-bottom: 1rem;
  /* Espaçamento inferior */
}

/* Estilo do formulário de inscrição da newsletter */
.newsletter__form {
  display: flex;
  /* Flexbox para organizar os elementos dentro */
  justify-content: center;
  /* Centraliza os itens horizontalmente */
}

/* Estilo do campo de entrada de e-mail */
.newsletter__input {
  padding: 10px;
  /* Espaçamento interno */
  border: none;
  /* Remove a borda padrão */
  border-radius: 5px 0 0 5px;
  /* Bordas arredondadas no lado esquerdo */
  font-size: 1rem;
  /* Tamanho da fonte */
}

/* Estilo do botão de inscrição */
.newsletter__button {
  padding: 10px;
  /* Espaçamento interno */
  border: none;
  /* Remove a borda padrão */
  border-radius: 0 5px 5px 0;
  /* Bordas arredondadas no lado direito */
  background-color: rgb(0, 43, 82);
  /* Cor de fundo */
  color: #FFF;
  /* Cor do texto */
  font-weight: 600;
  /* Peso da fonte em negrito */
  cursor: pointer;
  /* Indica que o botão é clicável */
  font-size: 1rem;
  /* Tamanho da fonte */
  transition: .3s;
  /* Transição suave */
}

/* Efeito ao passar o mouse sobre o botão de inscrição */
.newsletter__button:hover {
  transform: scale(1.2);
  /* Aumenta o tamanho do botão */
}

/* Estilo do contêiner do logo */
.footer__logo-container {
  margin: 2rem 0;
  /* Espaçamento superior e inferior */
}

/* Estilo do logo */
.footer__logo {
  width: 150px;
  /* Largura fixa do logo */
}

/* Estilo das seções do rodapé */
.footer__sections {
  display: flex;
  /* Flexbox para organizar as seções em linha */
  flex-wrap: wrap;
  /* Permite que as seções quebrem para a linha seguinte se necessário */
  justify-content: space-around;
  /* Distribui as seções de maneira espaçada */
  width: 100%;
  /* Ocupa 100% da largura do rodapé */
}

/* Estilo de cada seção individual */
.footer__section {
  margin: 1rem;
  /* Espaçamento entre as seções */
}

/* Estilo dos títulos das seções */
.footer__section h3 {
  font-size: 1.2rem;
  /* Tamanho da fonte */
  margin-bottom: 0.5rem;
  /* Espaçamento inferior */
}

/* Estilo das listas dentro das seções */
.footer__section ul {
  list-style: none;
  /* Remove os marcadores das listas */
  padding: 0;
  /* Remove o padding */
}

/* Estilo de cada item das listas */
.footer__section li {
  margin: 0.5rem 0;
  /* Espaçamento entre os itens */
}

/* Estilo dos links nas seções */
.footer__section a {
  color: #2C3E50;
  /* Cor do texto do link */
  text-decoration: none;
  /* Remove o sublinhado */
}

/* Efeito ao passar o mouse sobre os links */
.footer__section a:hover {
  text-decoration: underline;
  /* Adiciona o sublinhado quando o mouse passa sobre o link */
}

/* Estilo para a seção de redes sociais */
.footer__social {
  margin: 2rem 0;
  /* Espaçamento superior e inferior */
}

/* Estilo para os ícones de redes sociais */
.footer__social .social__icon {
  font-size: 24px;
  /* Tamanho do ícone */
  color: #333;
  /* Cor do ícone */
  margin: 0 10px;
  /* Espaçamento entre os ícones */
  text-decoration: none;
  /* Remove o sublinhado */
}

/* Efeito ao passar o mouse sobre os ícones das redes sociais */
.footer__social .social__icon:hover {
  color: #007bff;
  /* Muda a cor do ícone para azul ao passar o mouse */
}

/* Estilo para a parte inferior do rodapé */
.footer__bottom {
  margin-top: 1rem;
  /* Espaçamento superior */
  font-size: 0.9rem;
  /* Tamanho da fonte */
}

/* Estilo dos links na parte inferior do rodapé */
.footer__bottom a {
  color: rgb(0, 43, 82);
  /* Cor do link */
  font-weight: bold;
  /* Peso da fonte em negrito */
  text-decoration: none;
  /* Remove o sublinhado */
}

/* Efeito ao passar o mouse sobre os links da parte inferior */
.footer__bottom a:hover {
  text-decoration: underline;
  /* Adiciona o sublinhado ao passar o mouse */
}

/* Estilos para a responsividade em telas menores que 768px */
@media (max-width: 768px) {
  .footer__sections {
    flex-direction: column;
    /* Organiza as seções em coluna */
    align-items: center;
    /* Centraliza as seções */
  }

  .footer__section {
    margin-bottom: 1rem;
    /* Espaçamento inferior entre as seções */
  }
}

/* Estilos para a responsividade em telas menores que 480px */
@media (max-width: 480px) {

  /* Estilo do formulário de inscrição */
  .newsletter__form {
    flex-direction: column;
    /* Organiza o formulário em coluna */
  }

  /* Estilo do campo de entrada e do botão no formulário */
  .newsletter__input,
  .newsletter__button {
    width: 100%;
    /* Ocupa 100% da largura */
    margin-bottom: 0.5rem;
    /* Espaçamento inferior */
    border-radius: 5px;
    /* Bordas arredondadas */
  }
}
</style>
