<template>
  <div class="page__container">
    <div class="form__container">
      <form @submit="CreateUsuario" class="user__form__container">
        <h1 class="form__title">Cadastre-se</h1>
        <div class="form__grid">
          <div class="form__group">
            <label for="nome">Nome :</label>
            <input type="text" id="nome" v-model="nome" required />
          </div>

          <div class="form__group">
            <label for="idade">Idade :</label>
            <input type="number" id="idade" v-model="idade" required />
          </div>

          <div class="form__group">
            <label for="genero">Gênero :</label>
            <select id="genero" v-model="genero" required>
              <option value="" disabled>Selecione...</option>
              <option value="Masculino">Masculino</option>
              <option value="Feminino">Feminino</option>
            </select>
          </div>

          <div class="form__group">
            <label for="numero">Número :</label>
            <input type="number" id="numero" v-model="numero" required />
          </div>

          <div class="form__group">
            <label for="cep">CEP :</label>
            <input type="text" id="cep" v-model="cep" required />
          </div>

          <div class="form__group">
            <label for="tipoIdentificacao">Tipo de Identificação :</label>
            <select id="tipoIdentificacao" v-model="tipoIdentificacao" required>
              <option value="" disabled>Selecione...</option>
              <option value="cpf">CPF</option>
              <option value="cnpj">CNPJ</option>
              <option value="rg">RG</option>
              <option value="cnh">CNH</option>
              <!-- Outros tipos de identificação, se necessário -->
            </select>
          </div>

          <div class="form__group">
            <label for="identificacao">Identificação :</label>
            <input v-if="tipoIdentificacao" :placeholder="placeholderIdentificacao" v-model="identificacao" type="text"
              @input="atualizarIdentificacao" :maxlength="tipoIdentificacao === 'cnpj' ? 18 : 14" required />
          </div>

          <div class="form__group">
            <label for="username">Username :</label>
            <input type="text" id="username" v-model="username" required />
          </div>

          <div class="form__group">
            <label for="password">Password :</label>
            <input type="password" id="password" v-model="password" required />
          </div>

          <div class="form__group">
            <label for="image">Foto de Perfil:</label>
            <input type="file" id="image" @change="handleFileUpload" />
          </div>

        </div>

        <button type="submit" class="submit__btn">Cadastrar Usuário</button>
      </form>
    </div>

    <h1>Já tem um cadastro?</h1>
    <RouterLink to="Login" class="Entry__Bnt">Clique aqui para logar</RouterLink>
  </div>
</template>
<script>

export default {
  name: "Cadastro",
  data() {
    return {
      nome: '',
      idade: '',
      genero: '',
      cep: '',
      numero: '',
      tipoIdentificacao: '',
      identificacao: '',
      username: '',
      password: '',
      selectedFile: null
    };
  },
  computed: {
    placeholderIdentificacao() {
      switch (this.tipoIdentificacao) {
        case 'cpf': return 'Ex: 111.111.111-11';
        case 'cnpj': return 'Ex: 11.111.111/1111-11';
        case 'rg': return 'Ex: 12.345.678-9';
        case 'cnh': return 'Ex: 1234567890';
        default: return '';
      }
    }
  },
  watch: {
    tipoIdentificacao(newTipo) {
      this.identificacao = '';
    }
  },
  methods: {
    formatarCNPJ(cnpj) {
      cnpj = cnpj.replace(/\D/g, ""); // Remove caracteres não numéricos
      cnpj = cnpj.replace(/(\d{2})(\d)/, "$1.$2"); // Adiciona o primeiro ponto
      cnpj = cnpj.replace(/(\d{3})(\d)/, "$1.$2"); // Adiciona o segundo ponto
      cnpj = cnpj.replace(/(\d{3})(\d)/, "$1/$2"); // Adiciona a barra
      cnpj = cnpj.replace(/(\d{4})(\d{1,2})$/, "$1-$2"); // Adiciona o traço
      return cnpj;
    },

    formatarCPF(cpf) {
      cpf = cpf.replace(/\D/g, ""); // Remove caracteres não numéricos
      cpf = cpf.replace(/(\d{3})(\d)/, "$1.$2"); // Adiciona o primeiro ponto
      cpf = cpf.replace(/(\d{3})(\d)/, "$1.$2"); // Adiciona o segundo ponto
      cpf = cpf.replace(/(\d{3})(\d{1,2})$/, "$1-$2"); // Adiciona o traço
      return cpf;
    },

    atualizarIdentificacao(event) {
      const value = event.target.value;
      if (this.tipoIdentificacao === 'cpf') {
        this.identificacao = this.formatarCPF(value);
      } else if (this.tipoIdentificacao === 'cnpj') {
        this.identificacao = this.formatarCNPJ(value);
      }
    },

    handleFileUpload(event) {
      const file = event.target.files[0];
      if (file && file.type.startsWith('image/')) { // Verifica se o arquivo é uma imagem
        if (file.size > 5 * 1024 * 1024) { // Limita o tamanho a 5MB
          alert('O arquivo é muito grande. O tamanho máximo permitido é 5MB.');
          this.selectedFile = null;
        } else {
          this.selectedFile = file;
        }
      } else {
        alert('Por favor, selecione um arquivo de imagem válido.');
        this.selectedFile = null;
      }
    },

    async CreateUsuario(e) {
      e.preventDefault();

      try {
        const cepResponse = await this.GetCep();
        if (!cepResponse || !cepResponse.cep) {
          alert('CEP não encontrado ou inválido');
          return;
        }

        const data = {
          nome: this.nome,
          idade: parseInt(this.idade),
          genero: this.genero,
          cep: cepResponse.cep,
          rua: cepResponse.logradouro,
          numero: parseInt(this.numero),
          bairro: cepResponse.bairro,
          cidade: cepResponse.localidade,
          unidadeFederativa: cepResponse.uf,
          identificacao: this.identificacao,
          username: this.username,
          password: this.password,
        };

        const response = await fetch('https://localhost:7082/Usuario/AdicionarUsuario', {
          method: 'POST',
          headers: { 'Content-Type': 'application/json' },
          body: JSON.stringify(data),
        });

        const responseData = await response.json();
        const UsuarioId = responseData.id;

        if (response.status === 200) {
          this.PostImage(UsuarioId);
        } else {
          alert('Erro ao cadastrar o usuário.');
        }
      } catch (error) {
        alert('Erro ao tentar cadastrar o usuário.');
      }
    },

    PostImage(UsuarioId) {


      try {

        const formData = new FormData();
        formData.append("imagem", this.selectedFile);

        const responsePostImagem = fetch(`https://localhost:7082/Usuario/UploadImage?usuarioId=${UsuarioId}`, {
          method: "PUT",
          body: formData,
        });

        if (responsePostImagem.status === 200) {
          alert('Imagem carregada com sucesso!');
        } else {
          alert('Erro ao carregar a imagem.');
        }
      } catch (error) {
        alert('Erro ao tentar enviar a imagem.');
      }
    },

    async GetCep() {
      try {
        const response = await fetch(`https://viacep.com.br/ws/${this.cep}/json/`);
        if (!response.ok) {
          alert("Erro ao buscar o CEP.");
          return null;
        }
        const data = await response.json();
        return data;
      } catch (error) {
        alert("Erro ao buscar o CEP.");
        return null;
      }
    }
  }
};
</script>


<style scoped>
/* Container principal da página */
.page__container {
  display: flex;
  /* Usando flexbox para alinhamento */
  align-items: center;
  /* Alinha os itens verticalmente */
  justify-content: center;
  /* Centraliza os itens horizontalmente */
  flex-direction: column;
  /* Organiza os itens em coluna */
  width: 100%;
  /* Largura de 100% */
  height: 100%;
  /* Altura de 100% */
  padding: 20px;
  /* Espaçamento interno de 20px */
  background-color: #fff;
  /* Cor de fundo branca */
  font-family: "Funnel Display", sans-serif;
  /* Fonte personalizada */
}

/* Container do formulário */
.form__container {
  background-color: rgba(255, 255, 255, 0.9);
  /* Fundo branco com opacidade */
  padding: 30px;
  /* Espaçamento interno de 30px */
  border-radius: 12px;
  /* Bordas arredondadas */
  box-shadow: 0 4px 25px rgba(0, 0, 0, 0.2);
  /* Sombra suave ao redor */
  width: 100%;
  /* Largura de 100% */
  max-width: 900px;
  /* Largura máxima de 900px */
  backdrop-filter: blur(8px);
  /* Efeito de desfoque no fundo */
  animation: slideUp 1s ease-out;
  /* Animação para deslizar para cima */
}

/* Animação de deslizamento do formulário */
@keyframes slideUp {
  0% {
    transform: translateY(50px);
    /* Começa abaixo */
    opacity: 0;
    /* Começa invisível */
  }

  100% {
    transform: translateY(0);
    /* Finaliza na posição original */
    opacity: 1;
    /* Torna-se visível */
  }
}

/* Container do formulário do usuário */
.user__form__container {
  width: 100%;
  /* Largura de 100% */
  display: flex;
  /* Usando flexbox */
  flex-direction: column;
  /* Organiza os itens em coluna */
  align-items: center;
  /* Alinha os itens ao centro */
}

/* Título do formulário */
.form__title {
  font-size: 1.8rem;
  /* Tamanho da fonte */
  color: #333;
  /* Cor do texto */
  margin-bottom: 20px;
  /* Espaçamento abaixo */
  text-align: center;
  /* Alinha o texto ao centro */
  letter-spacing: 1px;
  /* Espaçamento entre letras */
  font-weight: 600;
  /* Peso da fonte */
}

/* Grid de formulários */
.form__grid {
  display: grid;
  /* Usando grid para layout */
  grid-template-columns: repeat(2, 1fr);
  /* Duas colunas de igual tamanho */
  gap: 20px;
  /* Espaçamento entre os itens */
  width: 100%;
  /* Largura de 100% */
}

/* Grupo de campo de formulário */
.form__group {
  display: flex;
  /* Usando flexbox */
  flex-direction: column;
  /* Organiza os itens em coluna */
}

/* Estilos para inputs e selects */
input,
select {
  padding: 12px;
  /* Padding de 12px */
  border-radius: 8px;
  /* Bordas arredondadas */
  border: 2px solid #ddd;
  /* Borda cinza clara */
  font-size: 1rem;
  /* Tamanho da fonte */
  margin-top: 5px;
  /* Espaçamento superior */
  transition: border-color 0.3s ease, background-color 0.3s ease;
  /* Transições suaves */
}

/* Foco nos campos de input e select */
input:focus,
select:focus {
  border-color: #fda085;
  /* Cor da borda ao focar */
  background-color: #fff;
  /* Cor de fundo branca */
}

/* Botão de envio */
.submit__btn {
  padding: 12px;
  /* Padding de 12px */
  background-color: rgb(0, 43, 82);
  /* Cor de fundo azul escuro */
  color: white;
  /* Cor do texto branca */
  border: none;
  /* Sem borda */
  border-radius: 8px;
  /* Bordas arredondadas */
  cursor: pointer;
  /* Cursor de ponteiro */
  width: 100%;
  /* Largura de 100% */
  margin-top: 20px;
  /* Espaçamento superior */
  font-size: 1.1rem;
  /* Tamanho da fonte */
  transition: background-color 0.3s ease;
  /* Transição suave para a cor de fundo */
}

/* Efeito hover no botão de envio */
.submit__btn:hover {
  background-color: #1a5276;
  /* Cor de fundo azul mais claro */
}

/* Link de entrada */
.Entry__Bnt {
  color: rgb(0, 43, 82);
  /* Cor azul escuro */
  font-weight: bold;
  /* Peso da fonte em negrito */
  text-decoration: none;
  /* Sem sublinhado */
  margin-top: 20px;
  /* Espaçamento superior */
  transition: color 0.3s ease;
  /* Transição suave para a cor */
}

/* Efeito hover no link de entrada */
.Entry__Bnt:hover {
  color: #1a5276;
  /* Cor azul mais claro */
}

/* Responsividade para telas pequenas */
@media (max-width: 768px) {
  .form__grid {
    grid-template-columns: 1fr;
    /* Uma coluna em telas pequenas */
  }

  .form__title {
    font-size: 1.5rem;
    /* Diminui o tamanho do título */
  }

  .submit__btn {
    font-size: 1rem;
    /* Diminui o tamanho da fonte do botão */
  }

  .page__container {
    padding: 20px;
    /* Diminui o padding */
  }

  .form__container {
    padding: 20px;
    /* Diminui o padding */
  }
}

/* Responsividade para telas muito pequenas */
@media (max-width: 480px) {
  .form__title {
    font-size: 1.3rem;
    /* Diminui ainda mais o tamanho do título */
  }

  .form__group input,
  .form__group select {
    font-size: 0.9rem;
    /* Diminui o tamanho da fonte dos inputs */
  }
}
</style>
