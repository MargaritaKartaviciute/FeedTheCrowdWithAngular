import requests
from bs4 import BeautifulSoup as soup
from fractions import Fraction

filename = "data.txt"
f = open(filename,"w", encoding='utf-8')

my_url = 'https://www.tasteofhome.com/course/page/'

for i in range(1, 1662):
    url = my_url + str(i)
    response = requests.get(url)
    html = response.content
    page_soup = soup(html, "html.parser")

    context = page_soup.findAll("li", {"class":"single-recipe"})
    for cont in context:
        link = cont.find("a")['href']
        # print(link)

        url = link
        response = requests.get(url)
        html = response.content
        page_soup = soup(html, "html.parser")

        page_context = page_soup.findAll("h4", {"class":"listicle-page__title"})
        for c in page_context:
            page_link = c.find("a")['href']

            print(page_link)
            page_url = page_link
            response = requests.get(page_url)
            html = response.content
            page_soup = soup(html, "html.parser")
            # print(page_soup)
            error = page_soup.find('div', {"class": "page-content error-content"})
            if (error == None):
                print("kazkas")
                context = page_soup.find("div", {"class":"recipe-ingredients"})
                if (context == None):
                    continue
                recipe_context = context.findAll("li")

                ingredients = []
                quantity = []
                valid = True
                for ingredient in recipe_context:
                    quan = ingredient.text.split(' ')[0]
                    if(quan.isdigit()):
                        quantity.append(quan)
                    else:
                        values = quan.split('/')
                        if(len(values) == 2 and all(i.isdigit() for i in values)):
                             quantity.append(str(float(values[0])/float(values[1])))
                        else:
                            valid = False
                            break
                    ingredients.append(ingredient.text.replace(ingredient.text.split(' ')[0], ' ').strip())

                servings = page_soup.find("div", {"class": "recipe-time-yield__label-servings"}).text.strip().split(' ')
                serving = '1'
                for serv in servings:
                    if(serv.isdigit()):
                        serving = serv
                        break
                image  = page_soup.find("div", {"class": "recipe-image-and-meta-sidebar__featured-container"}).find("img")['src']
                title = page_soup.find("h1", {"class": "recipe-title"}).text

                description_context = page_soup.findAll("li", {"class": "recipe-directions__item"})
                description = ''
                for desc in description_context:
                    description =  description + " " + desc.text.strip(' ')

                time = page_soup.find("div", {"class": "recipe-time-yield__label-prep"}).text.strip()

                if(valid == True):
                    string = time.replace(';', ',') + ";" + title.replace(';', ',') + ";" + image + ";" + serving + ";" + description.replace(';', ',') + ";"

                    for ing in ingredients:
                        string = string + ing + ":"
                    string  = string  + ";"
                    for i in quantity:
                        string = string + i + ":"
                    print(string)
                    f.write(string + "\n")
f.close()

