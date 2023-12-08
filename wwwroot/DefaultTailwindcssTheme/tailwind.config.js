/** @type {import('tailwindcss').Config} */

module.exports = {
  content: ["./**/*.{cshtml,razor,cs,css}"],
  darkMode: 'class',
  theme: {
    colors: {
      transparent: "transparent",
      inherit: "inherit",
      'dark-gray': {
        DEFAULT: "rgba(255, 255, 255, 0.1)",
        '5': "rgba(255, 255, 255, 0.05)",
        '10': "rgba(255, 255, 255, 0.1)",
        '15': "rgba(255, 255, 255, 0.15)",
        '20': "rgba(255, 255, 255, 0.2)",
        '30': "rgba(255, 255, 255, 0.3)",
        '50': "rgba(255, 255, 255, 0.5)",
        '60': "rgba(255, 255, 255, 0.6)",
        '70': "rgba(255, 255, 255, 0.7)",
      },
      'dark':{
        DEFAULT: "rgba(0, 0, 0, 0.89)",
        '1': "rgba(0, 0, 0, 0.01)",
        '5': "rgba(0, 0, 0, 0.05)",
        '6': "rgba(0, 0, 0, 0.06)",
        '10': "rgba(0, 0, 0, 0.10)",
        '15': "rgba(0, 0, 0, 0.15)",
        '20': "rgba(0, 0, 0, 0.20)",
        '30': "rgba(0, 0, 0, 0.30)",
        '40': "rgba(0, 0, 0, 0.40)",
        '80': "rgba(0, 0, 0, 0.40)",
        '90': "rgba(0, 0, 0, 0.90)",
      },
      'main-dark-background': "#242424",
      'main-light-background':"#f0f0f0",
      'white': "#FFFFFF",
      'yellow': "#FFB341",
      'blue': "rgba(0, 102, 255, 0.30)",
      'error': {
        DEFAULT: "#BB2200",
        light: "#FF0000",
        dark: "#9F0000",
      },
      'successful': {
        DEFAULT: "#2ECE51",
        light: "#009F23",
        dark: "#00881E",
      },
      'warning': {
        DEFAULT: "#FFD234",
        light: "#D9AF20",
        dark: "#CBA112",
      },
    },
    fontFamily: {
      inter: "Inter, sans-serif"
    },
    fontSize: {
      'h1': [ "32px", { lineHeight: "38.7px", fontWeight: "700" }],
      'h2': [ "28px", { lineHeight: "33.9px", fontWeight: "700" }],
      'h3': [ "24px", { lineHeight: "29px", fontWeight: "600" }],
      'h4': [ "20px", { lineHeight: "24.2px", fontWeight: "600" }],
      'h5': [ "18px", { lineHeight: "21.8px", fontWeight: "600" }],
      'h6': [ "16px", { lineHeight: "19.4px", fontWeight: "600" }],
      'header': [ "18px", { lineHeight: "21.8px", fontWeight: "600" }],
      'regular': [ "16px", { lineHeight: "19.4px", fontWeight: "500" }],
      'small': [ "14px", { lineHeight: "16.9px", fontWeight: "500" }],
      'heading': [ "14px", { lineHeight: "16.9px", fontWeight: "600", letterSpacing: "0.1em" }],
      'label-large': [ "1.25rem", { lineHeight: "1", fontWeight: "400", letterSpacing: "0.00938em" }],
      'label-small': [ "1.125rem", { lineHeight: "1", fontWeight: "400", letterSpacing: "0.00938em" }],
    },
    ringWidth: {
      DEFAULT: "6px",
    },
    boxShadow: {
      'sm': 'rgba(0, 0, 0, 0.12) 0px 0px 2px 0px, rgba(0, 0, 0, 0.14) 0px 1px 2px 0px',
      DEFAULT: 'rgba(0, 0, 0, 0.12) 0px 0px 2px 0px, rgba(0, 0, 0, 0.14) 0px 2px 4px 0px',
      'md': '0 4px 6px -1px rgb(0 0 0 / 0.1), 0 2px 4px -2px rgb(0 0 0 / 0.1)',
      'lg': '0 10px 15px -3px rgb(0 0 0 / 0.1), 0 4px 6px -4px rgb(0 0 0 / 0.1)',
      'xl': '0 20px 25px -5px rgb(0 0 0 / 0.1), 0 8px 10px -6px rgb(0 0 0 / 0.1)',
      '2xl': '0 25px 50px -12px rgb(0 0 0 / 0.25)',
      inner: 'inset 0 2px 4px 0 rgb(0 0 0 / 0.05)',
      none: 'none',
    },
    extend: {
      screens: {
        'xs': '375px',
      },
      aria: {
        currentPage: 'current="page"',
        invalid: 'invalid="true"',
      },
      outlineWidth: {
        6: "6px",
      },
      animation: {
        'zoom': 'zoom 0.3s',
      },
      keyframes: {
        'zoom': {
          '0%': { transform: 'scale(0.5)', opacity: '0' },
          '100%': { transform: 'scale(1)', opacity: '1' },
        },
      }
    },
  },
  plugins: [

  ]
};