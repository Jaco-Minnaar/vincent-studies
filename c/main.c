#include <stdio.h>
#include <stdbool.h> 

struct Todo {
    int id;
    int priority;
    bool is_done;
    char* text;
};

void print_todos();
void add_todo(struct Todo* todo);
void remove_todo();

int main() {
    printf("Hello World\n");
    
    int a = 5;
    int* b = &a;
    
    *b += 6;
    
    printf("Value of a: %i\n", a);
}
