#include <bits/stdc++.h>
using namespace std;
int space = 0;
int player = 1;
int rock = 2;
int tree = 3;
int block = 4;
float spawn_stone_rate = 0.5;
int area[7][14];

void PrintArea()
{
    for (int i = 0; i < 7; i++)
    {
        for (int j = 0; j < 14; j++)
        {
            if (area[i][j] == space)
                cout << " ";
            if (area[i][j] == player)
                cout << "P";
            if (area[i][j] == rock)
                cout << "X";
            if (area[i][j] == tree)
                cout << "t";
            if (area[i][j] == block)
                cout << "t";
        }
        cout << endl;
    }
}

void RandomStone()
{
    for (int i = 0; i < 7; i++)
    {
        for (int j = 0; j < 14; j++)
        {
            float r = (float)rand() / RAND_MAX;
            if (r < spawn_stone_rate)
                area[i][j] = rock;
            else
                area[i][j] = space;
        }
    }
    area[3][0] = 1;
}

bool CanPlayerPass()
{
    // bfs
    int visited[7][14] = {0};
    queue<pair<int, int>> q;
    q.push({3, 0});
    visited[3][0] = 1;
    while (!q.empty())
    {
        pair<int, int> p = q.front();
        q.pop();
        int x = p.first;
        int y = p.second;
        if (y == 13)
        {
            return true;
        }
        if (x - 1 >= 0 && area[x - 1][y] == space && visited[x - 1][y] == 0)
        {
            q.push({x - 1, y});
            visited[x - 1][y] = 1;
        }
        if (x + 1 < 7 && area[x + 1][y] == space && visited[x + 1][y] == 0)
        {
            q.push({x + 1, y});
            visited[x + 1][y] = 1;
        }
        if (y - 1 >= 0 && area[x][y - 1] == space && visited[x][y - 1] == 0)
        {
            q.push({x, y - 1});
            visited[x][y - 1] = 1;
        }
        if (y + 1 < 14 && area[x][y + 1] == space && visited[x][y + 1] == 0)
        {
            q.push({x, y + 1});
            visited[x][y + 1] = 1;
        }
    }
    return false;
}

void AddSomeStone()
{
    int arri[] = {0, 1, 2, 3, 4, 5, 6};
    int arrj[] = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13};

    random_shuffle(arri, arri + 7);
    random_shuffle(arrj, arrj + 14);

    int stone_count = 3;
    for (int i = 0; i < 7; i++)
    {
        for (int j = 0; j < 14; j++)
        {
            if (!stone_count)
                break;
            int ii = arri[i];
            int jj = arrj[j];
            if (area[ii][jj] == space)
            {
                stone_count--;
                float r = (float)rand() / RAND_MAX;
                if (r < spawn_stone_rate)
                    area[ii][jj] = rock;
            }
        }
    }
}

bool AddSomeTree()
{
    int arri[] = {0, 1, 2, 3, 4};
    int arrj[] = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12};
    int treeleft = rand() % 3;
    for (int i = 0; i < 7 - 2; i++)
    {
        for (int j = 0; j < 14 - 1; j++)
        {
            int tempi = i, tempj = j;
            random_shuffle(arri, arri + 5);
            random_shuffle(arrj, arrj + 13);
            i = arri[i];
            j = arrj[j];

            if (!treeleft)
                return true;
            if (area[i][j] == rock)
            {
                vector<int> v;
                for (int ii = i; ii < i + 3; ii++)
                {
                    for (int jj = j; jj < j + 2; jj++)
                    {
                        v.push_back(area[ii][jj]);
                    }
                }
                area[i][j] = tree;
                area[i][j + 1] = block;
                area[i + 1][j] = block;
                area[i + 1][j + 1] = block;
                area[i + 2][j] = block;
                area[i + 2][j + 1] = block;
                if (CanPlayerPass())
                {
                    treeleft--;
                    i++;
                    j++;
                }
                else
                {
                    area[i][j] = v[0];
                    area[i][j + 1] = v[1];
                    area[i + 1][j] = v[2];
                    area[i + 1][j + 1] = v[3];
                    area[i + 2][j] = v[4];
                    area[i + 2][j + 1] = v[5];
                }
            }

            i = tempi;
            j = tempj;
        }
    }
    return false;
}

void GetCode()
{
    cout << "area[0, 0] = rock;";
    cout << "area[6, 13] = rock;";
    for (int i = 0; i < 7; i++)
    {
        for (int j = 0; j < 14; j++)
        {
            if (area[i][j] == space)
            {
                // pass
            }
            else if (area[i][j] == rock)
            {
                cout << "area[" << i << ", " << j << "] = rock;";
            }
            else if (area[i][j] == player)
            {
                // pass
            }
            else if (area[i][j] == tree)
            {
                cout << "area[" << i << ", " << j << "] = tree;";
            }
            else if (area[i][j] == block)
            {
                // pass
            }
        }
    }
    cout << "area[3, 0] = player;";
    cout << endl;
}

int main()
{
    PrintArea();
    while (1)
    {
        system("cls");
        RandomStone();
        if (!CanPlayerPass())
        {
            continue;
        }
        AddSomeTree();
        while (CanPlayerPass())
        {
            AddSomeStone();
        }
        PrintArea();
        cout << "Want this map? (y/n)" << endl;
        char c;
        cin >> c;
        if (c == 'n')
            continue;
        GetCode();
        getchar();
        getchar();
    }
}