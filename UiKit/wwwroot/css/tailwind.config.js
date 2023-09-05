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
      'main-dark-background': "#242424",
      'main-light-background':"#EDEEF0",
      'white': "#FFFFFF",
      'black': "#000000",
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
      'h1': [ "32px", { lineHeight: "39px", fontWeight: "700" }],
      'h2': [ "28px", { lineHeight: "34px", fontWeight: "700" }],
      'h3': [ "24px", { lineHeight: "29px", fontWeight: "600" }],
      'h4': [ "20px", { lineHeight: "24px", fontWeight: "600" }],
      'h5': [ "18px", { lineHeight: "22px", fontWeight: "600" }],
      'h6': [ "16px", { lineHeight: "19px", fontWeight: "600" }],
      'header': [ "18px", { lineHeight: "30px", fontWeight: "600" }],
      'regular': [ "16px", { lineHeight: "19px", fontWeight: "500" }],
      'small': [ "14px", { lineHeight: "17px", fontWeight: "500" }],
      'heading': [ "14px", { lineHeight: "17px", fontWeight: "600", letterSpacing: "0.1em" }],
      'label-large': [ "1.25rem", { lineHeight: "1", fontWeight: "400", letterSpacing: "0.00938em" }],
      'label-small': [ "1.125rem", { lineHeight: "1", fontWeight: "400", letterSpacing: "0.00938em" }],
    },
    borderRadius: {
      DEFAULT: "6px",
      'sm': "4px",
      'xl': "0.75rem",
    },
    ringWidth: {
      DEFAULT: "6px",
    },
    extend: {
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
      },
    },
  },
  plugins: [

  ]
};