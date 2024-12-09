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
      <img src="@/Images/logo.png" alt="Logo Do Site" class="footer__logo" />
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
          <li><a href="#">Precificador</a></li>
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
.footer {
  background-color: #f3f7f8;
  color: #2C3E50;
  padding: 2rem;
  display: flex;
  flex-direction: column;
  align-items: center;
  text-align: center;
}

.footer__newsletter {
  margin-bottom: 2rem;
}

.footer__newsletter h2 {
  font-size: 1.5rem;
  margin-bottom: 0.5rem;
}

.footer__newsletter p {
  margin-bottom: 1rem;
}

.newsletter__form {
  display: flex;
  justify-content: center;
}

.newsletter__input {
  padding: 10px;
  border: none;
  border-radius: 5px 0 0 5px;
  font-size: 1rem;
}

.newsletter__button {
  padding: 10px;
  border: none;
  border-radius: 0 5px 5px 0;
  background-color: rgb(0, 43, 82);
  color: #FFF;
  font-weight: 600;
  cursor: pointer;
  font-size: 1rem;
  transition: .3s;
}

.newsletter__button:hover {
  transform: scale(1.2);
}

.footer__logo-container {
  margin: 2rem 0;
}

.footer__logo {
  width: 150px;
}

.footer__sections {
  display: flex;
  flex-wrap: wrap;
  justify-content: space-around;
  width: 100%;
}

.footer__section {
  margin: 1rem;
}

.footer__section h3 {
  font-size: 1.2rem;
  margin-bottom: 0.5rem;
}

.footer__section ul {
  list-style: none;
  padding: 0;
}

.footer__section li {
  margin: 0.5rem 0;
}

.footer__section a {
  color: #2C3E50;
  text-decoration: none;
}

.footer__section a:hover {
  text-decoration: underline;
}

.footer__social {
  margin: 2rem 0;
}

.footer__social .social__icon {
  font-size: 24px;
  color: #333;
  margin: 0 10px;
  text-decoration: none;
}

.footer__social .social__icon:hover {
  color: #007bff;
}

.footer__bottom {
  margin-top: 1rem;
  font-size: 0.9rem;
}


.footer__bottom a {
  color: rgb(0, 43, 82);
  font-weight: bold;
  text-decoration: none;
}

.footer__bottom a:hover {
  text-decoration: underline;
}

@media (max-width: 768px) {
  .footer__sections {
    flex-direction: column;
    align-items: center;
  }

  .footer__section {
    margin-bottom: 1rem;
  }
}

@media (max-width: 480px) {
  .newsletter__form {
    flex-direction: column;
  }

  .newsletter__input,
  .newsletter__button {
    width: 100%;
    margin-bottom: 0.5rem;
    border-radius: 5px;
  }
}
</style>
