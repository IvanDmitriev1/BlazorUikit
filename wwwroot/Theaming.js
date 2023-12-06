function ApplyTheme()
{
    const isDarkTheme = localStorage.theme === 'dark' || (!('theme' in localStorage) && window.matchMedia('(prefers-color-scheme: dark)').matches);
    if (isDarkTheme)
    {
        document.documentElement.classList.add('dark');
    }
    else
    {
        document.documentElement.classList.remove('dark');
    }
}

ApplyTheme();