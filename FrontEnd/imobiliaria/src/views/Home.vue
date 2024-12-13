<template>
  <div>
    <RouterView />

    <section class="Hero__bg">
      <Hero />
    </section>

    <section class="Delta">
      <Delta />
    </section>

    <section class="Echo">
      <Echo />
    </section>

    <section class="Alpha">
      <Alpha />
    </section>

  </div>
</template>


<script>
import Hero from '@/components/Hero.vue';
import Delta from '@/components/Delta.vue';
import Echo from '@/components/Echo.vue';
import Alpha from '@/components/Alpha.vue';
import NavBar from '@/components/NavBar.vue';
import MobileNavBar from '@/components/MobileNavBar.vue';

export default {
  name: 'Home',
  components: {
    Hero,
    Delta,
    Echo,
    Alpha,
    NavBar,
    MobileNavBar
  }
};
</script>

<style scoped>
/* Reset Global Styles */
/* Configuração para garantir que a largura e altura de todos os elementos sejam calculadas de forma consistente */
*,
*::before,
*::after {
  box-sizing: border-box;
  /* Inclui padding e border no cálculo de largura e altura */
}

/* Configurações globais para o body */
body {
  margin: 0;
  /* Remove a margem padrão do body */
  padding: 0;
  /* Remove o padding padrão do body */
  font-family: "Funnel Display", sans-serif;
  /* Define a fonte para a página */
}

/* Remove o sublinhado padrão dos links */
a {
  text-decoration: none;
  /* Remove o sublinhado dos links */
}

/* Estilo para o fundo da seção Hero */
.Hero__bg {
  position: relative;
  /* Define o contexto de posicionamento para elementos filhos */
  width: 100%;
  /* Largura total */
  height: 450px;
  /* Altura fixa da seção Hero */
  background: url('@/Images/bg.png') no-repeat center center;
  /* Definindo a imagem de fundo */
  background-size: cover;
  /* Faz a imagem de fundo cobrir a seção */
  display: flex;
  /* Usando flexbox para alinhar o conteúdo */
  justify-content: center;
  /* Centraliza o conteúdo horizontalmente */
}

/* Sombra escura sobre o fundo da seção Hero */
.Hero__bg::before {
  content: "";
  /* Cria um elemento vazio */
  position: absolute;
  /* Posiciona o elemento acima do fundo */
  top: 0;
  left: 0;
  width: 100%;
  /* Largura total */
  height: 100%;
  /* Altura total */
  background-color: rgba(0, 0, 0, 0.4);
  /* Cor de fundo semi-transparente */
  z-index: 1;
  /* Coloca esse elemento abaixo dos filhos diretos da Hero__bg */
}

/* Garante que o conteúdo da Hero__bg fique acima do pseudo-elemento ::before */
.Hero__bg>* {
  position: relative;
  /* Coloca os filhos acima do elemento pseudo criado */
  z-index: 2;
  /* Garante que o conteúdo principal fique visível acima da sobreposição */
}

/* Estilo para a seção Delta */
.Delta {
  background-color: #f3f7f8;
  /* Cor de fundo clara */
  color: #FFF;
  /* Cor do texto branca */
  height: 400px;
  /* Altura fixa */
  padding-inline: 5rem;
  /* Padding horizontal de 5rem */
  display: flex;
  /* Usando flexbox para alinhar o conteúdo */
  justify-content: center;
  /* Centraliza o conteúdo horizontalmente */
  align-items: center;
  /* Centraliza o conteúdo verticalmente */
}

/* Estilo para a seção Echo */
.Echo {
  height: 400px;
  /* Altura fixa */
  width: 100%;
  /* Largura total */
  display: flex;
  /* Usando flexbox */
  justify-content: center;
  /* Centraliza o conteúdo horizontalmente */
  align-items: center;
  /* Centraliza o conteúdo verticalmente */
}

/* Estilo para a seção Alpha */
.Alpha {
  height: 500px;
  /* Altura fixa */
  background-color: transparent;
  /* Fundo transparente */
  display: flex;
  /* Usando flexbox */
  justify-content: center;
  /* Centraliza o conteúdo horizontalmente */
  align-items: center;
  /* Centraliza o conteúdo verticalmente */
}

/* Estilos responsivos para telas maiores que 1280px */
@media (max-width: 1280px) {
  .Delta {
    height: 650px;
    /* Aumenta a altura da seção Delta */
  }

  .Content-section .Echo {
    width: 100%;
    /* Garante que a largura da Echo seja 100% */
    display: flex;
    /* Usando flexbox */
    justify-content: center;
    /* Centraliza o conteúdo horizontalmente */
    align-items: center;
    /* Centraliza o conteúdo verticalmente */
  }

  .Echo {
    height: 700px;
    /* Aumenta a altura da seção Echo */
    width: 100%;
    /* Garante que a largura da Echo seja 100% */
  }

  .Alpha {
    height: 500px;
    /* Mantém a altura da Alpha igual */
  }
}

/* Estilos responsivos para telas de até 1024px */
@media (max-width: 1024px) {
  .Hero__bg {
    height: 500px;
    /* Reduz a altura da Hero__bg */
  }

  .Delta {
    height: 1000px;
    /* Aumenta a altura da seção Delta */
  }

  .Echo {
    height: 1000px;
    /* Aumenta a altura da seção Echo */
    width: 100%;
    /* Garante que a largura da Echo seja 100% */
  }

  .Alpha {
    height: 700px;
    /* Aumenta a altura da seção Alpha */
  }
}

/* Estilos responsivos para telas de até 768px */
@media (max-width: 768px) {
  .Hero__bg {
    height: 400px;
    /* Diminui a altura da Hero__bg */
  }

  .Delta {
    height: 500px;
    /* Diminui a altura da Delta */
  }

  .Echo {
    height: 1000px;
    /* Aumenta a altura da Echo */
    width: 100%;
    /* Garante que a largura da Echo seja 100% */
  }

  .Alpha {
    height: 1000px;
    /* Aumenta a altura da Alpha */
  }
}

/* Estilos responsivos para telas de até 480px */
@media (max-width: 480px) {
  .Hero__bg {
    height: 500px;
    /* Ajusta a altura da Hero__bg */
  }

  .Delta {
    height: 1000px;
    /* Aumenta a altura da Delta */
  }
}

/* Estilos para telas entre 481px e 768px */
@media (min-width: 481px) and (max-width: 768px) {
  .Delta {
    height: 900px;
    /* Ajusta a altura da Delta */
  }
}
</style>