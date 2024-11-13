<template>
  <div>
    <header class="Nav__header">
      <NavBar v-show="!isMobile" />
      <MobileNavBar v-show="isMobile" />
    </header>

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
  </div>
</template>

<script>
import Hero from '@/components/Hero.vue';
import Delta from '@/components/Delta.vue';
import Echo from '@/components/Echo.vue';
import NavBar from '@/components/NavBar.vue';
import MobileNavBar from '@/components/MobileNavBar.vue';

export default {
  name: 'Home',
  components: {
    Hero,
    Delta,
    Echo,
    NavBar,
    MobileNavBar
  },
  data() {
    return {
      isMobile: false,
    };
  },
  mounted() {
    this.updateNavbarVisibility();
    window.addEventListener("resize", this.updateNavbarVisibility);
  },
  beforeDestroy() {
    window.removeEventListener("resize", this.updateNavbarVisibility);
  },
  methods: {
    updateNavbarVisibility() {
      this.isMobile = window.innerWidth < 1280;
    }
  }
};
</script>

<style scoped>
/* Reset Global Styles */
*,
*::before,
*::after {
  box-sizing: border-box;
}

body {
  margin: 0;
  padding: 0;
  font-family: Arial, sans-serif;
}

a {
  text-decoration: none;
}

.Nav__header {
  width: 100%;
}

.Hero__bg {
  position: relative;
  width: 100%;
  height: 500px;
  background: url('@/Images/bg.png') no-repeat center center;
  background-size: cover;
  display: flex;
  align-items: center;
  justify-content: center;
}

.Hero__bg::before {
  content: "";
  position: absolute;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  background-color: rgba(0, 0, 0, 0.4);
  z-index: 1;
}

.Hero__bg>* {
  position: relative;
  z-index: 2;
}

.Delta {
  background-color: #C1B49C;
  width: 100%;
  color: #FFF;
  padding-inline: 5rem;
  height: 400px;
  display: flex;
  justify-content: center;
  align-items: center;
}

.Echo {
  width: 100%;
  height: 700px;
  display: flex;
  justify-content: center;
  align-items: center;
}

@media (max-width: 1280px) {
  .Delta {
    height: 650px;
  }
}

@media (max-width: 1024px) {
  .Hero__bg {
    height: 500px;
  }

  .Delta {
    height: 600px;
  }
}

@media (max-width: 768px) {
  .Hero__bg {
    height: 400px;
  }

  .Delta {
    height: 500px;
  }
}

@media (max-width: 480px) {
  .Hero__bg {
    height: 400px;
  }

  .Delta {
    height: 1000px;
  }
}

@media (min-width: 481px) and (max-width: 768px) {
  .Delta {
    height: 900px;
  }
}

@media (min-width: 1280px) {
  .Hero__bg {
    height: 450px;
  }
}
</style>
