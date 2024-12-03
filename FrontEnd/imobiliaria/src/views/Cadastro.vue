<template>
  <div class="page-container">
    <div class="form-container">
      <form @submit.prevent="CreateUsuario" class="user-form-container">
        <h1 class="form-title">Cadastre-se</h1>

        <div v-if="message" :class="['message', message === 'Sucesso ao cadastrar o usuário.' ? 'success' : 'error']">
          {{ message }}
        </div>

        <div class="form-grid">
          <div class="form-group">
            <label for="nome">Nome:</label>
            <input type="text" id="nome" v-model="nome" required />
          </div>
          <div class="form-group">
            <label for="idade">Idade:</label>
            <input type="number" id="idade" v-model="idade" required />
          </div>
          <div class="form-group">
            <label for="genero">Gênero:</label>
            <select id="genero" v-model="genero" required>
              <option value="" disabled>Selecione...</option>
              <option value="Masculino">Masculino</option>
              <option value="Feminino">Feminino</option>
            </select>
          </div>
          <div class="form-group">
            <label for="numero">Número:</label>
            <input type="text" id="numero" v-model="numero" />
          </div>
          <div class="form-group">
            <label for="cep">CEP:</label>
            <input type="text" id="cep" v-model="cep" @blur="validateCep" required />
          </div>
          <div class="form-group">
            <label for="identificacao">Identificação:</label>
            <input type="text" id="identificacao" v-model="identificacao" required />
          </div>
          <div class="form-group">
            <label for="username">Username:</label>
            <input type="text" id="username" v-model="username" required />
          </div>
          <div class="form-group">
            <label for="password">Password:</label>
            <input type="password" id="password" v-model="password" required />
          </div>
          <div class="form-group">
            <label for="file">Imagem:</label>
            <input type="file" id="file" @change="onFileChange" required />
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
  name: "FormPostUsuario",
  data() {
    return {
      nome: "",
      idade: "",
      genero: "",
      cep: "",
      numero: "",
      rua: "",
      bairro: "",
      cidade: "",
      unidadeFederativa: "",
      identificacao: "",
      username: "",
      password: "",
      file: null,
      message: "",
    };
  },
  methods: {
    validateCep() {
      const cepPattern = /^[0-9]{8}$/;
      if (!cepPattern.test(this.cep)) {
        this.message = "CEP inválido. Certifique-se de inserir um CEP válido com 8 números.";
        this.cep = "";
      } else {
        this.message = "";
      }
    },
    onFileChange(event) {
      this.file = event.target.files[0];
    },
    async GetCep() {
      try {
        const response = await fetch(`https://viacep.com.br/ws/${this.cep}/json/`);
        if (!response.ok) {
          throw new Error("Erro ao buscar o CEP.");
        }
        const data = await response.json();
        if (data.erro) {
          throw new Error("CEP não encontrado.");
        }
        return data;
      } catch (error) {
        this.message = error.message;
        return null;
      }
    },
    async CreateUsuario() {
      if (!this.file) {
        this.message = "Por favor, selecione um arquivo.";
        return;
      }

      const cepResponse = await this.GetCep();
      if (!cepResponse) {
        return; // Interrompe se o CEP for inválido ou a busca falhar
      }

      const formData = new FormData();
      formData.append("file", this.file);
      formData.append("Nome", this.nome);
      formData.append("Idade", this.idade);
      formData.append("Genero", this.genero);
      formData.append("CEP", this.cep);
      formData.append("Rua", cepResponse.logradouro || "");
      formData.append("Numero", this.numero);
      formData.append("Bairro", cepResponse.bairro || "");
      formData.append("Cidade", cepResponse.localidade || "");
      formData.append("UnidadeFederativa", cepResponse.uf || "");
      formData.append("Identificacao", this.identificacao);
      formData.append("Username", this.username);
      formData.append("Password", this.password);

      try {
        const response = await fetch("https://localhost:7082/Usuario/AdicionarUsuario", {
          method: "POST",
          body: formData,
        });

        if (response.ok) {
          this.message = "Sucesso ao cadastrar o usuário.";
          this.resetForm();
        } else {
          const errorData = await response.json();
          this.message = `Erro ao cadastrar o usuário: ${JSON.stringify(errorData.errors)}`;
        }
      } catch (error) {
        this.message = "Erro ao conectar com o servidor. Tente novamente.";
        console.error("Erro no CreateUsuario:", error);
      }
    },
    resetForm() {
      this.nome = "";
      this.idade = "";
      this.genero = "";
      this.cep = "";
      this.numero = "";
      this.rua = "";
      this.bairro = "";
      this.cidade = "";
      this.unidadeFederativa = "";
      this.identificacao = "";
      this.username = "";
      this.password = "";
      this.file = null;
      this.$refs.fileInput.value = ""; // Reseta o campo de upload
    },
  },
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