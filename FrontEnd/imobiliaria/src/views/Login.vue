<template>
  <div class="Login__container">
    <div class="login__background">
      <form @submit="loginUsuario" class="login-form">
        <h1 class="form-title">Faça Login</h1>

        <div class="form__group">
          <label for="username">Username:</label>
          <input type="text" id="username" v-model="username" required />
        </div>

        <div class="form__group">
          <label for="password">Password:</label>
          <input type="password" id="password" v-model="password" required />
        </div>

        <button type="submit" class="submit__btn">Entrar</button>

        <div class="signup__prompt">
          <h2>Ainda não tem cadastro?</h2>
          <RouterLink to="/Cadastro" class="signup__link">Criar Conta</RouterLink>
        </div>
      </form>
    </div>
  </div>
</template>

<script>
export default {
  name: 'Login',
  data() {
    return {
      username: '',
      password: ''
    };
  },
  methods: {
    async loginUsuario(e) {
      e.preventDefault();

      const data = {
        username: this.username,
        password: this.password
      };

      const dataJson = JSON.stringify(data);

      try {
        const req = await fetch('https://localhost:7082/Usuario/LogarUsuario', {
          method: 'POST',
          headers: { 'Content-Type': 'application/json' },
          body: dataJson,
        });

        // Verificar se a resposta é ok (status 200)
        if (!req.ok) {
          throw new Error('Login falhou, verifique suas credenciais.');
        }

        const usuario = await req.json();

        // Verificar se as credenciais são válidas
        if (usuario.username === this.username && usuario.password === this.password) {
          // Armazenar usuário no estado global (store)
          this.$store.dispatch('setUsuario', usuario);

          // Redirecionar para a página principal após login bem-sucedido
          this.$router.push('/');
        } else {
          alert('Credenciais inválidas');
        }
      } catch (error) {
        console.error(error);
        alert('Erro ao fazer login. Tente novamente mais tarde.');
      }
    }
  }
};
</script>

<style scoped>
/* Container principal da página de login */
.Login__container {
  display: flex;
  /* Usando flexbox para centralizar o conteúdo */
  justify-content: center;
  /* Alinha o conteúdo horizontalmente ao centro */
  align-items: center;
  /* Alinha o conteúdo verticalmente ao centro */
  height: 100vh;
  /* Altura igual à altura da janela de visualização */
  background-color: #f3f7f8;
  /* Cor de fundo clara */
  overflow: hidden;
  /* Evita que o conteúdo ultrapasse os limites da tela */
  position: relative;
  /* Contexto de posicionamento para os filhos */
}

/* Estilo do fundo da caixa de login */
.login__background {
  position: relative;
  /* Posicionamento relativo para o conteúdo dentro */
  display: flex;
  /* Usando flexbox para centralizar o conteúdo */
  justify-content: center;
  /* Alinha o conteúdo horizontalmente ao centro */
  align-items: center;
  /* Alinha o conteúdo verticalmente ao centro */
  padding: 40px;
  /* Padding interno */
  background-color: rgba(255, 255, 255, 0.85);
  /* Cor de fundo branca com opacidade */
  border-radius: 10px;
  /* Bordas arredondadas */
  box-shadow: 0 4px 30px rgba(0, 0, 0, 0.1);
  /* Sombra suave ao redor */
  backdrop-filter: blur(10px);
  /* Desfoque do fundo para dar um efeito visual */
  animation: slideIn 1s ease-out;
  /* Animação de deslizamento de entrada */
  max-width: 450px;
  /* Largura máxima do contêiner */
  width: 100%;
  /* Largura total */
}

/* Animação de entrada da caixa de login */
@keyframes slideIn {
  0% {
    transform: translateY(-50px);
    /* Inicia a animação deslocando para cima */
    opacity: 0;
    /* Inicia invisível */
  }

  100% {
    transform: translateY(0);
    /* Finaliza na posição original */
    opacity: 1;
    /* Torna-se visível */
  }
}

/* Estilo do título do formulário */
.form-title {
  font-size: 2rem;
  /* Tamanho da fonte */
  color: #333;
  /* Cor do texto */
  margin-bottom: 20px;
  /* Margem inferior */
  font-family: "Funnel Display", sans-serif;
  /* Definição da fonte */
  text-align: center;
  /* Centraliza o texto */
  letter-spacing: 1px;
  /* Espaçamento entre as letras */
}

/* Estilo dos grupos de campos no formulário */
.form__group {
  margin-bottom: 20px;
  /* Espaçamento inferior entre os campos */
}

/* Estilo para os rótulos dos campos */
.form__group label {
  font-size: 1.1rem;
  /* Tamanho da fonte */
  color: #666;
  /* Cor do texto */
  margin-bottom: 8px;
  /* Margem inferior */
}

/* Estilo para os inputs dentro dos grupos */
.form__group input {
  width: 100%;
  /* Largura total do input */
  padding: 15px;
  /* Padding interno */
  border: 2px solid #ddd;
  /* Borda suave e cinza */
  border-radius: 8px;
  /* Bordas arredondadas */
  font-size: 1rem;
  /* Tamanho da fonte */
  background-color: #f9f9f9;
  /* Cor de fundo clara */
  color: #333;
  /* Cor do texto */
  transition: all 0.3s ease;
  /* Transição suave em todas as propriedades */
}

/* Estilo para o input quando estiver em foco */
.form__group input:focus {
  border-color: #1c92d2;
  /* Cor da borda quando o input está em foco */
  background-color: #fff;
  /* Cor de fundo branca quando em foco */
}

/* Estilo para o botão de submit */
.submit__btn {
  width: 100%;
  /* Largura total do botão */
  padding: 12px;
  /* Padding interno */
  background-color: rgb(0, 43, 82);
  /* Cor de fundo do botão */
  color: white;
  /* Cor do texto do botão */
  border: none;
  /* Sem borda */
  border-radius: 8px;
  /* Bordas arredondadas */
  font-size: 1.1rem;
  /* Tamanho da fonte */
  cursor: pointer;
  /* Cursor de ponteiro para indicar que é clicável */
  transition: background-color 0.3s ease;
  /* Transição suave para a cor de fundo */
}

/* Estilo do botão de submit quando o mouse passa sobre ele */
.submit__btn:hover {
  background-color: #1A5276;
  /* Cor de fundo alterada quando em hover */
}

/* Estilo do prompt de cadastro */
.signup__prompt {
  text-align: center;
  /* Centraliza o texto */
  margin-top: 20px;
  /* Margem superior */
}

/* Estilo do título dentro do prompt de cadastro */
.signup__prompt h2 {
  font-size: 1.2rem;
  /* Tamanho da fonte */
  color: #666;
  /* Cor do texto */
  margin-bottom: 10px;
  /* Margem inferior */
}

/* Estilo do link de cadastro */
.signup__link {
  font-weight: bold;
  /* Texto em negrito */
  color: rgb(0, 43, 82);
  /* Cor do texto */
  text-decoration: none;
  /* Remove o sublinhado do link */
  font-size: 1.1rem;
  /* Tamanho da fonte */
  transition: color 0.3s ease;
  /* Transição suave para a cor */
}

/* Estilo do link de cadastro quando em hover */
.signup__link:hover {
  color: #1A5276;
  /* Cor do link alterada quando o mouse passa sobre ele */
}
</style>
