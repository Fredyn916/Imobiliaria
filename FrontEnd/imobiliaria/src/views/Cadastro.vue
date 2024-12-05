<template>
  <div class="page-container">
    <div class="form-container">
      <form @submit="CreateUsuario" class="user-form-container">
        <h1 class="form-title">Cadastre-se</h1>

        <div v-if="message" :class="['message', message === 'Sucesso ao Cadastrar o usuário.' ? 'success' : 'error']">
          {{ message }}
        </div>

        <div class="form-grid">
          <div class="form-group">
            <label for="nome">Nome :</label>
            <input type="text" id="nome" v-model="nome" required />
          </div>

          <div class="form-group">
            <label for="idade">Idade :</label>
            <input type="number" id="idade" v-model="idade" required />
          </div>

          <div class="form-group">
            <label for="genero">Gênero :</label>
            <select id="genero" v-model="genero" required>
              <option value="" disabled>Selecione...</option>
              <option value="Masculino">Masculino</option>
              <option value="Feminino">Feminino</option>
            </select>
          </div>

          <div class="form-group">
            <label for="numero">Número :</label>
            <input type="number" id="numero" v-model="numero" required />
          </div>

          <div class="form-group">
            <label for="cep">CEP :</label>
            <input type="text" id="cep" v-model="cep" required />
          </div>

          <div class="form-group">
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

          <div class="form-group">
            <label for="identificacao">Identificação :</label>
            <input v-if="tipoIdentificacao" :placeholder="placeholderIdentificacao" v-model="identificacao" type="text" @input="atualizarIdentificacao" :maxlength="tipoIdentificacao === 'cnpj' ? 18 : 14" required />
          </div>

          <div class="form-group">
            <label for="username">Username :</label>
            <input type="text" id="username" v-model="username" required />
          </div>

          <div class="form-group">
            <label for="password">Password :</label>
            <input type="password" id="password" v-model="password" required />
          </div>

          <div class="form-group">
            <label for="image">Foto de Perfil:</label>
            <input type="file" id="image" @change="handleFileUpload" required />
          </div>

        </div>

        <button type="submit" class="submit-btn">Cadastrar Usuário</button>
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
      UsuarioId: '',
      selectedFile: null,
      message: ''
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
    formatarCPF(cpf) {
      cpf = cpf.replace(/\D/g, ""); // Remove caracteres não numéricos
      cpf = cpf.replace(/(\d{3})(\d)/, "$1.$2"); // Adiciona o primeiro ponto
      cpf = cpf.replace(/(\d{3})(\d)/, "$1.$2"); // Adiciona o segundo ponto
      cpf = cpf.replace(/(\d{3})(\d{1,2})$/, "$1-$2"); // Adiciona o traço
      return cpf;
    },
    atualizarIdentificacao(event) {
      if (this.tipoIdentificacao === 'cpf') {
        this.identificacao = this.formatarCPF(event.target.value);
      }
    },
    handleFileUpload(event) {
      this.selectedFile = event.target.files[0];
    },

    async CreateUsuario(e) {
      e.preventDefault();

      if (!this.selectedFile) {
        this.message = 'Por favor, selecione uma imagem.';
        return;
      }

      const cepResponse = await this.GetCep();
      if (!cepResponse) return;

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
      const responseID = responseData.id;

      const formData = new FormData();
      formData.append("imagem", this.selectedFile);

      const responsePostImagem = await fetch(`https://localhost:7082/Usuario/UploadImage?usuarioId=${responseID}`, {
        method: "PUT",
        body: formData,
      });

      if (response.ok && responsePostImagem.ok) {
        this.message = 'Sucesso ao Cadastrar o usuário.';
      } else {
        this.message = 'Erro ao Cadastrar o usuário.';
      }
    },
    async GetCep() {
      try {
        const response = await fetch(`https://viacep.com.br/ws/${this.cep}/json/`);
        if (!response.ok) {
          this.message = "Erro ao buscar o CEP.";
          return null;
        }
        const data = await response.json();
        return data;
      } catch (error) {
        this.message = "Erro ao buscar o CEP.";
        return null;
      }
    }
  }
};
</script>

<style scoped>
.page-container {
  display: flex;
  align-items: center;
  justify-content: center;
  flex-direction: column;
  width: 100%;
  height: 100%;
  padding: 20px;
  background-color: #fff;
  font-family: 'Poppins', sans-serif;
}

.form-container {
  background-color: rgba(255, 255, 255, 0.9);
  padding: 30px;
  border-radius: 12px;
  box-shadow: 0 4px 25px rgba(0, 0, 0, 0.2);
  width: 100%;
  max-width: 900px;
  backdrop-filter: blur(8px);
  animation: slideUp 1s ease-out;
}

@keyframes slideUp {
  0% {
    transform: translateY(50px);
    opacity: 0;
  }

  100% {
    transform: translateY(0);
    opacity: 1;
  }
}

.user-form-container {
  width: 100%;
  display: flex;
  flex-direction: column;
  align-items: center;
}

.form-title {
  font-size: 1.8rem;
  color: #333;
  margin-bottom: 20px;
  text-align: center;
  letter-spacing: 1px;
  font-weight: 600;
}

.form-grid {
  display: grid;
  grid-template-columns: repeat(2, 1fr);
  gap: 20px;
  width: 100%;
}

.form-group {
  display: flex;
  flex-direction: column;
}

input,
select {
  padding: 12px;
  border-radius: 8px;
  border: 2px solid #ddd;
  font-size: 1rem;
  margin-top: 5px;
  transition: border-color 0.3s ease, background-color 0.3s ease;
}

input:focus,
select:focus {
  border-color: #fda085;
  background-color: #fff;
}

.submit-btn {
  padding: 12px;
  background-color: rgb(0, 43, 82);
  color: white;
  border: none;
  border-radius: 8px;
  cursor: pointer;
  width: 100%;
  margin-top: 20px;
  font-size: 1.1rem;
  transition: background-color 0.3s ease;
}

.submit-btn:hover {
  background-color: #1a5276;
}

.message {
  margin-bottom: 20px;
  padding: 10px;
  border-radius: 5px;
  text-align: center;
}

.message.success {
  background-color: #d4edda;
  color: #155724;
}

.message.error {
  background-color: #f8d7da;
  color: #721c24;
}

.Entry__Bnt {
  color: rgb(0, 43, 82);
  font-weight: bold;
  text-decoration: none;
  margin-top: 20px;
  transition: color 0.3s ease;
}

.Entry__Bnt:hover {
  color: #1a5276;
}

/* Responsividade */
@media (max-width: 768px) {
  .form-grid {
    grid-template-columns: 1fr;
  }

  .form-title {
    font-size: 1.5rem;
  }

  .submit-btn {
    font-size: 1rem;
  }

  .page-container {
    padding: 20px;
  }

  .form-container {
    padding: 20px;
  }
}

@media (max-width: 480px) {
  .form-title {
    font-size: 1.3rem;
  }

  .form-group input,
  .form-group select {
    font-size: 0.9rem;
  }
}
</style>
