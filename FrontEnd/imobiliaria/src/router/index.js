import { createRouter, createWebHistory } from "vue-router";
import Home from "../views/Home.vue";

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: "/",
      name: "home",
      component: Home,
    },
    {
      path: "/Login",
      name: "Login",
      component: () => import("@/views/Login.vue"),
    },
    {
      path: "/Cadastro",
      name: "Cadastro",
      component: () => import("@/views/Cadastro.vue"),
    },
    {
      path: "/AnunciarSeuImovel",
      name: "AnunciarSeuImovel",
      component: () => import("@/views/AnunciarSeuImovel.vue"),
    },
    {
      path: "/ViewOneImovelCasa",
      name: "ViewOneImovelCasa",
      component: () => import("@/views/ViewOneImovelCasa.vue"),
      props: true,
    },
    {
      path: "/ViewOneImovelApartamento",
      name: "ViewOneImovelApartamento",
      component: () => import("@/views/ViewOneImovelApartamento.vue"),
      props: true,
    },
    {
      path: "/ViewOneImovelComercial",
      name: "ViewOneImovelComercial",
      component: () => import("@/views/ViewOneImovelComercial.vue"),
      props: true,
    },
    {
      path: "/ViewOneImovelLote",
      name: "ViewOneImovelLote",
      component: () => import("@/views/ViewOneImovelLote.vue"),
      props: true,
    },
    {
      path: "/ViewOneImovelTerreno",
      name: "ViewOneImovelTerreno",
      component: () => import("@/views/ViewOneImovelTerreno.vue"),
      props: true,
    },
    {
      path: "/ViewOneImovelRural",
      name: "ViewOneImovelRural",
      component: () => import("@/views/ViewOneImovelRural.vue"),
      props: true,
    },
    {
      path: "/ViewImovel",
      name: "ViewImovel",
      component: () => import("@/views/ViewImovel.vue"),
      props: true,
    },
    {
      path: "/ViewImovelComprar",
      name: "ViewImovelComprar",
      component: () => import("@/views/ViewImovelComprar.vue"),
      props: true,
    },
    {
      path: "/ViewImovelAlugar",
      name: "ViewImovelAlugar",
      component: () => import("@/views/ViewImovelAlugar.vue"),
      props: true,
    },
    {
      path: "/UsuarioPage",
      name: "UsuarioPage",
      component: () => import("@/views/UsuarioPage.vue"),
    },
    {
      path: "/Contato",
      name: "Contato",
      component: () => import("@/views/Contato.vue"),
    },
    {
      path: "/SobreNos",
      name: "SobreNos",
      component: () => import("@/views/SobreNos.vue"),
    },
    {
      path: "/TermosDeUso",
      name: "TermosDeUso",
      component: () => import("@/views/TermosDeUso.vue"),
    },
    {
      path: "/BeforeAddImovel",
      name: "BeforeAddImovel",
      component: () => import("@/views/BeforeAddImovel.vue"),
    },
  ],

  // Função para rolar a página para o topo
  scrollBehavior(to, from, savedPosition) {
    // Sempre que navegar para uma nova rota, a página rola para o topo
    return { top: 0, behavior: "smooth" };
  },
});

export default router;
